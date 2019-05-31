using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Custom.Winform
{
    public partial class FrmDatagridView : Form
    {
        public FrmDatagridView()
        {
            InitializeComponent();
        }

        private void FrmDatagridView_Load(object sender, EventArgs e)
        {

        }


        private BindingList<User> List = new BindingList<User>();


        public class User : INotifyPropertyChanged
        {
            public User()
            {
                userId = Guid.NewGuid().ToString("N");
            }

            private string userId;

            public string UserId
            {
                get { return userId; }
                set
                {
                    if (userId != value)
                    {
                        userId = value;
                        PropertyChanged(this, new PropertyChangedEventArgs("UserId"));
                    }
                }
            }
            private DateTime date;

            public DateTime Date
            {
                get { return date; }
                set
                {
                    if (date != value)
                    {
                        date = value;
                        PropertyChanged(this, new PropertyChangedEventArgs("Date"));
                    }
                }
            }

            private string message;

            public string Message
            {
                get { return message; }
                set
                {
                    if (message != value)
                    {
                        message = value;
                        PropertyChanged(this, new PropertyChangedEventArgs("Message"));
                    }
                }
            }

            public event PropertyChangedEventHandler PropertyChanged = (sender, args) => { };
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            List.Clear();

            for (int i = 0; i < 10; i++)
            {
                var u = new User() { Date = DateTime.Now };
                List.Add(u);
            }

            dataGridView1.DataSource = List;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var u = new User() { Date = DateTime.Now };
            List.Add(u);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            List.Remove(List.LastOrDefault());
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var u = List.OrderBy(p => Guid.NewGuid()).FirstOrDefault();
            if (u != null)
                u.Message = "123";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            List.Clear();
        }



    }
}
