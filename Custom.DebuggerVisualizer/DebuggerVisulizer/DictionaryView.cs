using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Custom.DebuggerVisualizer.V12.Core;
using Custom.DebuggerVisualizer.V12.Models;

namespace Custom.DebuggerVisualizer.V12.DebuggerVisulizer
{
    public partial class DictionaryView : Form
    {
        public DictionaryView()
        {
            InitializeComponent();
        }

        IDictionary _dictionay = null;
        public DictionaryView(IDictionary dictionary)
            : this()
        {
            _dictionay = dictionary;
        }

        private void DictionaryView_Load(object sender, EventArgs e)
        {
            SetDictionary(_dictionay);
        }


        public void SetDictionary(IDictionary dictionary)
        {
            List<DictionaryView_Model> result = new List<DictionaryView_Model>();
            foreach (DictionaryEntry item in dictionary)
            {
                var v = new DictionaryView_Model { Key = ConvertToString(item.Key), Value = ConvertToString(item.Value) };
                result.Add(v);
            }

            dataGridView.DataSource = result;

        }


        private string ConvertToString(object obj)
        {
            string result = "";

            if (obj.IsObjectNotNull())
            {
                Type type = obj.GetType();
                if (type.IsValueType)
                {
                    return obj.ToString();
                }

                return obj.ToString();

            }

            return result;
        }



    }
}
