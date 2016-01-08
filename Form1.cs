using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int[,] pole = new int[3, 3];    
        public Graphics pole1;
        private void button1_Click(object sender, EventArgs e)
        {
            e1 = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    pole[i, j] = 0;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    ocenka[i, j] = 0;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    ozenkac[i, j] = 0;
                }
            }


            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    massivsum[i, j] = 0;
                }

            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    massivsumc[i, j] = 0;
                }

            }
            pole1 = pictureBox1.CreateGraphics();
            Color clr = new Color();
            clr = Color.White;
            pole1.Clear(clr);

            for (int i = 0; i < 4; i++)
            {
                pole1.DrawLine(Pens.Black, 15, 15 + i * 90, 285, 15 + i * 90);
                pole1.DrawLine(Pens.Black, 15 + i * 90, 15, 15 + i * 90, 285);
            }
            if (radioButton1.Checked)
            {
                MessageBox.Show("Первым ходит компьютер");
                pole[1, 1] = 2;
                pole1.DrawEllipse(Pens.Red, 1 * 90 + 15, 1 * 90 + 15, 90, 90);
                hod = false;
            }
            if (radioButton2.Checked)
            {
                MessageBox.Show("Первым ходит человек");
            }
        }

        private int x;
        private int y;
        private bool hod = false;
        double[,] ozenkac = new double[3, 3];
        double[,] ocenka = new double[3, 3];
        int[,] massivsum = new int[3, 3];
        int[,] massivsumc = new int[3, 3];
        int e1;
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            e1++;
            int i = 0;
            int j = 0;
             if ((e.X > 15) && (e.X < 285) && (e.Y > 15) && (e.Y < 285))
            {

                x = ((e.X - 15) / 90) * 90 + 15;
                y = ((e.Y - 15) / 90) * 90 + 15;
                j = (e.X - 15) / 90;
                i = (e.Y - 15) / 90;
            


                
                if ((pole[i, j] == 0)&&(hod==false))
                {
                    pole1.DrawLine(Pens.Blue, x, y, x + 90, y + 90);
                    pole1.DrawLine(Pens.Blue, x + 90, y, x, y + 90);
                    pole[i, j] = 1;

                    if ((radioButton1.Checked == true))
                    {
                        hod = true;
                        win();
                        comp();
                        win();
                    }
                    else {
                        if (e1 == 1)
                        {
                            if ((pole[1, 1] == 1))
                            {
                                pole[0, 0] = 2;
                                pole1.DrawEllipse(Pens.Red, 15, 15, 90, 90);
                                hod = false;
                            }
                            if ((pole[1, 1] != 1))
                            {
                                pole[1, 1] = 2;
                                pole1.DrawEllipse(Pens.Red, 1 * 90 + 15, 1 * 90 + 15, 90, 90);
                                hod = false;
                            }

                        }
                        else {
                            hod = true;
                            win();
                            comp();
                            win();
                        
                        
                        }
                    
                    }
             
            if (winigrok == false) { win(); } 
                }
                else
                {    
                    MessageBox.Show("Cюда ходить нельзя");
                }

                


            }
        }
        double ozenkamoja = 0;
        double ozenkacomp = 0;
        public void comp()
        {  
            int j0=0, i0=0;
            int j01=0, i01=0;
            int jr=0, ir=0;
            double max1 = 0;
            double max2 = 0;
            summa();
            
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    ozenkacomp = Math.Pow(2, (double)massivsumc[i, j]);
                    ozenkamoja =Math.Pow(2, (double)massivsum[i, j]);
                    ocenka[i, j] = ozenkamoja;
                    ozenkac[i, j] = ozenkacomp;
                }
            }

            if (hod == true)
            {
                for (int i = 0; i < 3; i++)
                {

                    for (int j = 0; j < 3; j++)
                    {
                        if (pole[i, j] == 0) {
                            if ((ocenka[i, j] > max1))
                        {
                            max1 = ocenka[i, j];
                            i0 = i;
                            j0 = j;
                        }
                        if ((ozenkac[i, j] > max2))
                        {
                            max2 = ozenkac[i, j];
                            i01 = i;
                            j01 = j;
                        } }
                        
                    }

                }

            }
            if (max2 > max1)
            {
                jr = j01;
                ir = i01;
            }
            else
            {
            jr = j0;
            ir = i0;
            }
            if (pole[ir, jr] == 0) {
                pole1.DrawEllipse(Pens.Red, jr * 90 + 15, ir * 90 + 15, 90, 90);
            pole[ir, jr] = 2; }

            hod = false;
        }
          int i1, j1; 
      public  void summa()
        {   int g=0;
        int sum1;
        int sum2;
        int sum3;
        int sum4;
        int sum1c;
        int sum2c;
        int sum3c;
        int sum4c;
        int[] massivi = new int[8];
        int[] massivj = new int[8];
        int[] summa = new int[4];
        int[] summac = new int[4];
        for (int i = 0; i < 8; i++)
        {
            massivi[i] = 0;
            massivj[i] = 0;
        } 
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {       
                    if (pole[i, j] == 0){
                        g++;
                        i1 = i;
                        j1 = j;
                    massivi[g-1] = i;
                    massivj[g-1] = j; 
                    }   
                }
            }            
                    sum1 = 0;
                    sum1c = 0;
                    sum2 = 0;
                    sum3 = 0;
                    sum3c = 0;
                    sum2c = 0;
                    sum4 = 0;
                    sum4c = 0;
            for (int i = 0; i < 8; i++)
            {
                i1 = massivi[i];
                j1 = massivj[i]; 
                int k1 = 0;
                int k2 = 0;
                int m1 = 0;
                int m2 = 0;
                int l1 = 0;
                int l2 = 0;
                int s1 = 0;
                int s2 = 0;
                    if ((i1 != j1)&&(i1!=2-j1))
                    {
                        for (int i2 = 0; i2 < 3; i2++)
                        {
                            if (pole[i2, j1] == 2)
                            {
                                k1++;
                            }
                            if (pole[i2, j1] == 1)
                            {
                                k2++;
                            }
                            if ((k1 == 2) || (k2 == 2))
                            {
                                sum1c = k1 + 4;
                                sum1 = k2 + 6;
                            }
                            else {
                                sum1c = k1;
                                sum1 = k2;
                            }
                            
                        }
                        for (int j2 = 0; j2 < 3; j2++)
                        {
                            if (pole[i1, j2] == 2)
                            {
                                m1++;
                            }
                            if (pole[i1, j2] == 1)
                            {
                                m2++;
                            }
                            if ((m1 == 2) || (m2 == 2))
                            {
                                sum2c = m1 + 4;
                                sum2 = m2 + 6;
                            }
                            else
                            {
                                sum2c = m1;
                                sum2 = m2;
                            } 

                        }
                    }
                    else
                    {
                        for (int i2 = 0; i2 < 3; i2++)
                        {
                            if (pole[i2, j1] == 2)
                            {
                                k1++;
                            }
                            if (pole[i2, j1] == 1)
                            {
                                k2++;
                            }
                            if ((k1 == 2) || (k2 == 2))
                            {
                                sum1c = k1 + 4;
                                sum1 = k2 + 6;
                            }
                            else
                            {
                                sum1c = k1;
                                sum1 = k2;
                            }

                        }
                        for (int j2 = 0; j2 < 3; j2++)
                        {
                            if (pole[i1, j2] == 2)
                            {
                                m1++;
                            }
                            if (pole[i1, j2] == 1)
                            {
                                m2++;
                            }
                            if ((m1 == 2) || (m2 == 2))
                            {
                                sum2c = m1 + 4;
                                sum2 = m2 + 6;
                            }
                            else
                            {
                                sum2c = m1;
                                sum2 = m2;
                            }

                        }
                        if (i1 == j1)
                        {
                            for (int j2 = 0; j2 < 3; j2++)
                            {
                                if (pole[j2, j2] == 2)
                                {
                                    l1++;
                                }
                                if (pole[j2, j2] == 1)
                                {
                                    l2++;
                                }
                                if ((l1 == 2) || (l2 == 2))
                                {
                                    sum3c = l1 + 4;
                                    sum3 = l2 + 6;
                                }
                                else
                                {
                                    sum3c = l1;
                                    sum3 = l2;
                                } 
                            }
                        }
                        if (i1 == 2 - j1)
                        {
                            for (int j2 = 0; j2 < 3; j2++)
                            {
                            

                                if (pole[j2, 2 - j2] == 2)
                                {
                                    s1++;
                                }
                                if (pole[j2, 2 - j2] == 1)
                                {
                                    s2++;
                                }
                                if ((s1 == 2) || (s2 == 2))
                                {
                                    sum4c = s1 + 4;
                                    sum4 = s2 + 6;
                                }
                                else
                                {
                                    sum4c = s1;
                                    sum4 = s2;
                                }
  
                            }
                        }
                    }
                summa[0] = sum1;
                summa[1] = sum2;
                summa[2] = sum3;
                summa[3] = sum4;
                summac[0] = sum1;
                summac[1] = sum2;
                summac[2] = sum3;
                summac[3] = sum4;
            massivsum[i1, j1] = summa.Max();
            massivsumc[i1, j1] = summac.Max();
            }  
               }
      bool winigrok = false;
      void win() {     int k = 0;
          for (int i = 0; i < 3; i++) {
              if ((pole[i, 0] == pole[i, 1]) && (pole[i, 1] == pole[i, 2]) && (pole[i, 1] == 2)) { k = 5; }
              if ((pole[0, i] == pole[1, i]) && (pole[2, i] == pole[1, i]) && (pole[1, i] == 2)) { k = 5; }
              if ((pole[i, 0] == pole[i, 1]) && (pole[i, 1] == pole[i, 2]) && (pole[i, 1] == 1)) { k = 3; }
              if ((pole[0, i] == pole[1, i]) && (pole[2, i] == pole[1, i]) && (pole[1, i] == 1)) { k = 3; }
          }
          if ((pole[0, 0] == pole[1, 1]) && (pole[1, 1] == pole[2, 2]) && (pole[1, 1] == 1)) { k = 3; }
          if ((pole[0, 2] == pole[1, 1]) && (pole[2, 0] == pole[1, 1]) && (pole[1, 1] == 1)) { k = 3; }
          if ((pole[0, 0] == pole[1, 1]) && (pole[1, 1] == pole[2, 2]) && (pole[1, 1] == 2)) { k = 5; }
          if ((pole[0, 2] == pole[1, 1]) && (pole[2, 0] == pole[1, 1]) && (pole[1, 1] == 2)) { k = 5; }
          if (k == 5) {MessageBox.Show("Компьютер победил");};
          if (k == 3) { MessageBox.Show("Ты победил");
          winigrok = true;
          };
          int s = 0;
          for (int i = 0; i < 3; i++)
          {
              for (int j = 0; j < 3; j++) {

                  if (pole[i, j] != 0) {
                      s++;
                  }
              }

          }
          if ((s == 9) && (k != 3) && (k != 5)) { MessageBox.Show("Ничья"); }
      }

     
          }
      } 
     
        
    


