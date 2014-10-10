using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C1CoinFlip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    }

    public class side
    {
        private string _Name;
        private float _Weight;
        
        public string Name
        {
            set { this._Name = value; }
            get { return this.Name;  }
        }
        
        public float Weight
        {
            set { this._Weight = value; }
            get { return this._Weight; }
        }
    }

    public interface Die //no clue if I need to do anything else
    {
        
        public side roll();
        public List<side> getSides();
    }

    
}
