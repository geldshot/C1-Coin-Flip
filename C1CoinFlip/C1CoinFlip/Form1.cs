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
        private double _Weight;
        
        public string Name
        {
            set { this._Name = value; }
            get { return this.Name;  }
        }
        
        public double Weight
        {
            set { this._Weight = value; }
            get { return this._Weight; }
        }
    }

    public interface Die //no clue if I need to do anything else
    {
        
        side roll();
    }

    public class QuarterCoin : Die
    {
        private List<side> _Faces;
        private side _FaceUp;
        private double totalValue;

        public QuarterCoin(List<side> sides)
        {
            this._Faces = sides;
            this._FaceUp = this._Faces[0];
            this.totalValue = calculateTotalValue();
        }

        public List<side> Faces
        {
            get { return this._Faces; }
            set { this._Faces = value; }
        }

        public side roll()
        {
            Random ran = new Random();
            double  ranNum = ran.NextDouble() * this.totalValue;
            this._FaceUp = hashSide(ranNum);
            return _FaceUp;
        }

        public side addFace
        {
            set { 
                this._Faces.Add(value);
                this.totalValue = calculateTotalValue();
            }
        }

        public side FaceUp
        {
            get { return this._FaceUp; }
            set { this._FaceUp = value; }
        }

        private double calculateTotalValue()
        {
            double totVal = 0;
            
            foreach (side face in this._Faces)
            {
                if (face.Weight >= 0)
                    totVal += face.Weight;
            }

            return totVal;
        }

        private side hashSide(double value)
        {
            foreach (side face in this._Faces)
            {
                if (face.Weight >= 0)
                    value = value - face.Weight;
                if (value <= 0)
                    return face;
            }

            return this._Faces[this._Faces.Count - 1];

        }

    }
}
