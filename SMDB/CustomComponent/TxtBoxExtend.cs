using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomComponent
{
    public partial class TxtBoxExtend : TextBox
    {
        public TxtBoxExtend()
        {
            InitializeComponent();
        }

        public TxtBoxExtend(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }


        //扩展非空验证

        public int BeginValiateIsEmpty()
        {
            if (this.Text.Trim().Length == 0)
            {
                this.errorProvider.SetError(this, "不能为空!");
                return 0;
            }
            else
            {
                this.errorProvider.SetError(this, string.Empty);
                return 1;
            }

        }


    }
}
