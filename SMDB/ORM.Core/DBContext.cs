using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Core
{
    /// <summary>
    /// ORM框架核心类（数据库上下文类）
    /// 功能：封装CRUD方法
    /// </summary>
    public class DbContext
    {
        #region 封装Insert方法
        public int AddModel<T>(T model)
        {
            //【1】通过反射，获取实体的所有属性
            PropertyInfo[] allProperty =   model.GetType().GetProperties();

            //【2】封装SQL语句和参数变量
            StringBuilder sqlFiled = new StringBuilder($"insert into {model.GetType().Name} (");
            StringBuilder sqlValues = new StringBuilder($" values(");
            List<SqlParameter> parameterList = new List<SqlParameter>();

            #region 根据特性过滤不需要的属性
            //【4】根据特性过滤不需要的属性
            List<string> filterProperties = new List<string>();
            foreach (PropertyInfo property in allProperty)
            {
                object[] cstAttributes = property.GetCustomAttributes(true);
                foreach (var attribute in cstAttributes)
                {
                    if (attribute.GetType().Name.Equals("IdentityAttribute") ||
                        attribute.GetType().Name.Equals("ExtendPropertyAttribute"))
                    {
                        filterProperties.Add(property.Name);
                        break;
                    }
                }
            }
            #endregion

            #region 通过循环生成SQL语句和参数封装
            //【3】通过循环生成SQL语句和参数封装
            foreach (PropertyInfo property in allProperty)
            {
                //【5】过滤不需要的属性
                if (filterProperties.Contains(property.Name)) continue;
                //获取属性的值
                var propertyValue = property.GetValue(model);

                #region MyRegion
                //【6】优化：参数值优化
                if (propertyValue == null) continue;
                if (property.PropertyType == typeof(DateTime))
                {
                    DateTime dt;
                    DateTime.TryParse(propertyValue.ToString(), out dt);
                    if (dt<System.Data.SqlTypes.SqlDateTime.MinValue.Value) continue;
                }
                #endregion
                //生成SQL语句
                sqlFiled.Append($"{property.Name},");
                sqlValues.Append($"@{property.Name},");
                parameterList.Add(new SqlParameter($"@{property.Name}", propertyValue));
            }
            #endregion

            //【4】组合sql语句
            string sql = sqlFiled.ToString().TrimEnd(',') + ")" + sqlValues.ToString().TrimEnd(',') + ")";
            return SQLHelper.Update(sql,parameterList.ToArray());
        }
        #endregion

        #region 封装update、delete方法
        public int Update<T>(T model)
        {
            //【1】通过反射，获取实体的所有属性
            PropertyInfo[] allProperty = model.GetType().GetProperties();
            #region 通过特性过滤不需要赋值的属性
            //【3】通过特性过滤不需要赋值的属性
            List<string> filterProperties = new List<string>();
            Dictionary<string,int> primaryKey = new Dictionary<string, int>();
            foreach (PropertyInfo property in allProperty)
            {
                object[] ctsAttributes = property.GetCustomAttributes(true);
                foreach (var attribute in ctsAttributes)
                {
                    if (attribute.GetType().Name.Equals("PrimaryKeyAttribute"))
                    {
                        primaryKey.Add($"{property.Name}", Convert.ToInt32(property.GetValue(model)));

                    }
                    if (attribute.GetType().Name.Equals("IdentityAttribute") ||
                        attribute.GetType().Name.Equals("ExtendPropertyAttribute"))
                    {
                        filterProperties.Add(property.Name);
                        break;
                    }
                }
            }
            #endregion

            //【2】封装SQL语句和参数变量
            StringBuilder sqlFiled = new StringBuilder($"update {model.GetType().Name} set ");
            List<SqlParameter> parameterList = new List<SqlParameter>();
            foreach (PropertyInfo property in allProperty)
            {
                if (filterProperties.Contains(property.Name)) continue;
                //获取属性的值
                var propertyValue = property.GetValue(model);
                //【4】参数优化
                if(propertyValue==null) continue;
                if (property.PropertyType == typeof(DateTime))
                {
                    DateTime dt;
                    DateTime.TryParse(propertyValue.ToString(), out dt);
                    if (dt<System.Data.SqlTypes.SqlDateTime.MinValue.Value) continue;

                }
                sqlFiled.Append($"{property.Name}=@{property.Name},");
                parameterList.Add(new SqlParameter($"@{property.Name}", propertyValue));
            }
            //【5】组装SQL语句
            string sql = sqlFiled.ToString().TrimEnd(',') + $" where {primaryKey.Keys.First()}={primaryKey.Values.First()}";
            return SQLHelper.Update(sql, parameterList.ToArray());
        }

        public int Delete<T>(T model)
        {
            //【1】通过反射，获取实体的所有属性
            PropertyInfo[] allProperty = model.GetType().GetProperties();
            #region 通过特性过滤不需要赋值的属性
            Dictionary<string, int> primaryKey = new Dictionary<string, int>();
            foreach (PropertyInfo property in allProperty)
            {
                object[] ctsAttributes = property.GetCustomAttributes(true);
                foreach (var attribute in ctsAttributes)
                {
                    if (attribute.GetType().Name.Equals("PrimaryKeyAttribute"))
                    {
                        primaryKey.Add($"{property.Name}", Convert.ToInt32(property.GetValue(model)));
                    }
                }
            }
            #endregion

            //【2】封装SQL语句和参数变量
            StringBuilder sql = new StringBuilder($"delete from {model.GetType().Name} where {primaryKey.Keys.First()}=@{primaryKey.Keys.First()} ");
            List<SqlParameter> parameterList = new List<SqlParameter>();
            parameterList.Add(new SqlParameter($"{primaryKey.Keys.First()}",primaryKey.Values.First()));
            return SQLHelper.Update(sql.ToString(), parameterList.ToArray());
        }
        #endregion

        #region 封装Select方法
        public List<T> GetAllModeList<T>(IDataReader reader)
            where T:class,new()
        {
            //【1】获取当前查询的所有列的名称
            var fieldCount = reader.FieldCount;
            List<string> fieldNames = new List<string>();
            for (int i = 0; i < fieldCount; i++)
            {
                fieldNames.Add(reader.GetName(i).ToLower());
            }
            //【2】获取所有的属性
            PropertyInfo[] allProperty = typeof(T).GetProperties();
            List<T> modelList = new List<T>();
            while (reader.Read())
            {
                T model = new T();
                foreach (PropertyInfo property in allProperty)
                {
                    //【3】找到与要封装的字段相同的属性，并封装具体值
                    if (fieldNames.Contains(property.Name.ToLower()))
                    {
                        //给当前属性赋值
                        property.SetValue(model,Convert.ChangeType(reader[property.Name], property.PropertyType),null);
                    }
                }
                modelList.Add(model);
            }
            reader.Close();
            return modelList;
        }
        #endregion
    }
}
