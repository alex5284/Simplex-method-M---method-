using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dgMatrix.RowHeadersVisible = false;
            dg2.RowHeadersVisible = false;
            dgF.RowHeadersVisible = false;
            dgMatrix.AllowUserToAddRows = false;
            dg2.AllowUserToAddRows = false;
            dgF.AllowUserToAddRows = false;
        }
        int n = 0; int m = 0;
        List<List<double>> P;
        List<List<double>> X_i;
        List<double> P0, F;
        List<string> Znak;
        string max_or_min = "";
        void CreateMatrix2()
        {
            n = Convert.ToInt32(tbn.Text);
            m = Convert.ToInt32(tbm.Text);
            dgMatrix.Rows.Clear();
            dgMatrix.Columns.Clear();

            dg2.Rows.Clear();
            dg2.Columns.Clear();

            dgF.Rows.Clear();
            dgF.Columns.Clear();
            for (int i = 0; i < m; i++)
            {
                dgMatrix.Columns.Add("x" + i.ToString(), "x" + i.ToString());
                dgF.Columns.Add("x" + i.ToString(), "x" + i.ToString());
            }

            dgMatrix.Columns.Add("R", "R");
            dg2.Columns.Add("", "");

            dgMatrix.Rows.Add(n);
            dg2.Rows.Add(n);
            dgF.Rows.Add(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    dgMatrix.Rows[i].Cells[j].Value = "1"; // записываем значеня в соответсвующие места
                    if(i == 0) dgF.Rows[0].Cells[j].Value = "1";
                }
                dg2.Rows[i].Cells[0].Value = "=";
            }
        }

        void CreateMatrixTest()
        {
            n = 4;
            m = 4;
            tbn.Text = n.ToString();
            tbm.Text = m.ToString();
            dgMatrix.Rows.Clear();
            dgMatrix.Columns.Clear();

            dg2.Rows.Clear();
            dg2.Columns.Clear();

            dgF.Rows.Clear();
            dgF.Columns.Clear();
            for (int i = 0; i < m; i++)
            {
                dgMatrix.Columns.Add("x" + i.ToString(), "x" + i.ToString());
                dgF.Columns.Add("x" + i.ToString(), "x" + i.ToString());
            }

            dgMatrix.Columns.Add("R", "R");
            dg2.Columns.Add("", "");

            dgMatrix.Rows.Add(n);
            dg2.Rows.Add(n);
            dgF.Rows.Add(1);

            int j = 0;

            dgMatrix.Rows[j].Cells[0].Value = "1";
            dgMatrix.Rows[j].Cells[1].Value = "2";
            dgMatrix.Rows[j].Cells[2].Value = "3";
            dgMatrix.Rows[j].Cells[3].Value = "4";
            dgMatrix.Rows[j].Cells[4].Value = "1";

            dg2.Rows[j].Cells[0].Value = ">=";

            dgF.Rows[j].Cells[0].Value = "1";
            dgF.Rows[j].Cells[1].Value = "1";
            dgF.Rows[j].Cells[2].Value = "1";
            dgF.Rows[j].Cells[3].Value = "1";

            j = 1;
            dgMatrix.Rows[j].Cells[0].Value = "2";
            dgMatrix.Rows[j].Cells[1].Value = "1";
            dgMatrix.Rows[j].Cells[2].Value = "3";
            dgMatrix.Rows[j].Cells[3].Value = "1";
            dgMatrix.Rows[j].Cells[4].Value = "1";

            dg2.Rows[j].Cells[0].Value = ">=";

            j = 2;
            dgMatrix.Rows[j].Cells[0].Value = "1";
            dgMatrix.Rows[j].Cells[1].Value = "2";
            dgMatrix.Rows[j].Cells[2].Value = "2";
            dgMatrix.Rows[j].Cells[3].Value = "3";
            dgMatrix.Rows[j].Cells[4].Value = "1";

            dg2.Rows[j].Cells[0].Value = ">=";

            j = 3;
            dgMatrix.Rows[j].Cells[0].Value = "2";
            dgMatrix.Rows[j].Cells[1].Value = "4";
            dgMatrix.Rows[j].Cells[2].Value = "2";
            dgMatrix.Rows[j].Cells[3].Value = "3";
            dgMatrix.Rows[j].Cells[4].Value = "1";

            dg2.Rows[j].Cells[0].Value = ">=";

            cb.SelectedIndex = 0;
        }

        void ReadAll()
        {
            n = Convert.ToInt32(tbn.Text);
            m = Convert.ToInt32(tbm.Text);
            P = new List<List<double>>();
            X_i = new List<List<double>>();
            P0 = new List<double>();
            F = new List<double>();
            Znak = new List<string>();

            for (int i = 0; i < n; i++)
            {
                List<double> temp = new List<double>();
                for (int j = 0; j < m; j++)
                {
                    temp.Add(Convert.ToDouble(dgMatrix.Rows[i].Cells[j].Value));
                    //P[i, j] = Convert.ToDouble(dgMatrix.Rows[i].Cells[j].Value);
                    if (i == 0) F.Add(Convert.ToDouble(dgF.Rows[i].Cells[j].Value));
                }
                P.Add(temp);
                P0.Add(Convert.ToDouble(dgMatrix.Rows[i].Cells[m].Value));
                Znak.Add(Convert.ToString(dg2.Rows[i].Cells[0].Value));
            }
            max_or_min = (string)cb.SelectedItem;

            for(int i = 0; i < m; i++)
            {
                List<double> temp = new List<double>();
                for (int j = 0; j < n; j++)
                {
                    temp.Add(Convert.ToDouble(dgMatrix.Rows[j].Cells[i].Value));
                }
                X_i.Add(temp);
            }
        }

        void Calc()
        {
            ReadAll();
            listBox1.Items.Clear();
            //List<List<double>> new_p = new List<List<double>>();
            List<int> index = new List<int>();
            for(int i = 0; i < P0.Count(); i++)//Змінюємо всі вільні члени на додатні
            {
                if (P0[i] < 0)
                {
                    index.Add(i);
                    P0[i] *= -1;
                }
            }
            if(index.Count > 0)
            {
                for (int i = 0; i < index.Count; i++)
                {
                    for(int j = 0; j < X_i.Count; j++)
                    {
                        X_i[j][index[i]] *= -1;
                    }
                    if (Znak[index[i]] == "<=") Znak[index[i]] = ">=";
                    else if (Znak[index[i]] == ">=") Znak[index[i]] = "<=";
                }
            }

            for(int i = 0; i < Znak.Count; i++)//Змінюємо нерівність на рівність
            {
                List<double> temp = new List<double>();
                for(int j = 0; j < Znak.Count; j++)
                {
                    if (Znak[i] == ">=")
                    {
                        if (i == j) temp.Add(-1);
                        else temp.Add(0);
                    }
                    else if(Znak[i] == "<=")
                    {
                        if (i == j) temp.Add(1);
                        else temp.Add(0);
                    }
                }
                if (temp.Count > 0)
                {
                    X_i.Add(temp);
                    F.Add(0);
                }
            }
            int baz_count = Znak.Count;
            index.Clear();
            List<int> index2 = new List<int>();
            List<int> index3 = new List<int>();
            List<int> indexM = new List<int>();
            for (int i = 0; i < X_i.Count; i++) //Починаємо рахувати кількість базисних зміних
            {
                int c_0 = 0, c = 0;
                for (int j = 0; j < X_i[i].Count; j++)
                {
                    if (X_i[i][j] < 0)
                    {
                        if(j < X_i[i].Count - 1) break;
                        else
                        {
                            c_0++;
                            break;
                        }
                    }
                    else
                    {
                        if (X_i[i][j] == 0) c_0++;
                        else c = j;
                    }
                }
                if (c_0 == X_i[i].Count - 1)
                {
                    index.Add(i);
                    index2.Add(c);
                }
            }

            if(index.Count < baz_count)
            {
                for(int i = 0; i < Znak.Count(); i++)//Визначаємо строку де немає bазисної зміної
                {
                    if (!index2.Contains(i)) index3.Add(i);
                }
                
                for(int i = 0; i < index3.Count; i++)//Додаємо зміні М
                {
                    List<double> temp = new List<double>();
                    for(int j = 0; j < X_i[i].Count; j++)
                    {
                        if (j == index3[i]) temp.Add(1);
                        else temp.Add(0);
                    }
                    X_i.Add(temp);
                    index.Add(X_i.Count-1);
                    indexM.Add(X_i.Count - 1);
                    index2.Add(index3[i]);
                    if (max_or_min == "MAX") F.Add(-1);
                    else if (max_or_min == "MIN") F.Add(1);
                }
                if (max_or_min == "MIN")
                {
                    for (int i = 0; i < F.Count; i++)
                    {
                        F[i] *= -1;
                    }
                }
                double sign = 0;
                List<Tuple<int, int>> tupleM = new List<Tuple<int, int>>();// 1 - номер строки; 2 індекс - номер столбца;
                for (int i = 0; i < index3.Count; i++)
                {
                    Tuple<int, int> tuple = new Tuple<int, int>(index3[i], indexM[i]);
                    tupleM.Add(tuple);
                }
                List<double> deltaM = new List<double>();
                List<double> delta = new List<double>();
                bool t = false;
                List<Tuple<double, int, int>> Cb;
                int iter = 0;
                do
                {
                    iter++;
                    Cb = new List<Tuple<double, int, int>>();// Створюю Cb где первое значение єто значения в рядке Cb, второе это рядок где стоит базис, третье - строка где стоит еденица
                    Tuple<double, int, int> cb = new Tuple<double, int, int>(0, 0, 0); ;
                    for (int i = 0; i < index.Count; i++)
                    {
                        if(index2.Contains(i)) cb = new Tuple<double, int, int>(F[index[i]], index[i], index2[i]);
                        else if (index3.Contains(i)) cb = new Tuple<double, int, int>(F[index[i]], index[i], index3[i]);
                        Cb.Add(cb);
                    }
                    Cb = Cb.OrderBy(cb1 => cb1.Item3).ToList();
                    List<int> num_N = new List<int>();
                    List<int> num_not_N = new List<int>();
                    List<int> num_not_N_sort = new List<int>();


                    for (int i = 0; i < index2.Count; i++)// Дивлюся на якій стрічці стоїть М на якій ні
                    {
                        if (!index3.Contains(index2[i]))
                        {
                            num_not_N.Add(index2[i]);
                            num_not_N_sort.Add(index2[i]);
                        }
                    }
                    for (int i = 0; i < tupleM.Count; i++)
                    {
                        int c = 0;
                        for(int j = 0; j < Cb.Count; j++)
                        {
                            if (Cb[j].Item2 == tupleM[i].Item2)
                            {
                                c = 1;
                                break;
                            }
                        }
                        if(c == 1) num_N.Add(tupleM[i].Item1);
                    }
                    deltaM = new List<double>();
                    delta = new List<double>();
                    num_not_N_sort.Sort();
                    if (num_N.Count > 0)//якщо М у базисі
                    {
                        sign = F[F.Count - 1];
                        for (int i = 0; i < F.Count + 1; i++)// рахуємо дельта(значення біля М)
                        {
                            double c = 0;
                            for(int j = 0; j < num_N.Count; j++)
                            {
                                if(i == 0)
                                {
                                    c += (P0[num_N[j]] * sign);
                                }
                                else
                                {
                                    c += (X_i[i - 1][num_N[j]] * sign);
                                }
                            }
                            deltaM.Add(c);
                        }
                        for (int i = 0; i < index.Count; i++)
                        {
                            deltaM[index[i] + 1] = 0;
                        }
                    }

                    for (int i = 0; i < F.Count + 1; i++)//рахуємо просто дельта
                    {
                        double c = 0;
                        for (int j = 0; j < num_not_N.Count; j++)
                        {
                            if (i == 0)
                            {
                                c += (P0[num_not_N_sort[j]] * Cb[num_not_N_sort[j]].Item1);
                            }
                            else
                            {
                                c += (X_i[i - 1][num_not_N[j]] * Cb[num_not_N[j]].Item1);
                            }
                        }
                        if (i == 0) delta.Add(c);
                        else delta.Add(c - F[i - 1]);
                    }
                    for (int i = 0; i < index.Count; i++)
                    {
                        delta[index[i] + 1] = 0;
                    }

                    double max = 0;
                    int ind = 0;
                    if (deltaM.Count > 0)//якщо дельта М не порожня(тобто у базисі ще залишилося М)
                    {
                        max = deltaM[1];//шукаємо найбільше від'єме число у дельта М
                        for (int i = 2; i < deltaM.Count; i++)
                        {
                            if (deltaM[i] < max)
                            {
                                max = deltaM[i];
                                ind = i - 1;
                            }
                        }
                    }
                    double max2 = delta[1];

                    if (max >= 0)//якщо зміні М всі додатні у дельта М, то шукаємо від'ємні у дельта
                    {
                        for (int i = 2; i < delta.Count; i++)
                        {
                            if (delta[i] < max2)
                            {
                                max2 = delta[i];
                                ind = i - 1;
                            }
                        }
                        if (max2 >= 0)
                        {
                            if (max_or_min == "MIN")
                                listBox1.Items.Add(Math.Round(delta[0] * (-1), 3));
                            else listBox1.Items.Add(Math.Round(delta[0], 3));
                            string str = "{ ";
                            int count = 0;
                            Cb = Cb.OrderBy(cb1 => cb1.Item2).ToList();
                            List<double> indexes = new List<double>();
                            List<double> indexes2 = new List<double>();
                            for (int i = 0; i < Cb.Count; i++)
                            {
                                indexes.Add(Cb[i].Item2);
                                indexes2.Add(Cb[i].Item3);
                            }
                            for (int i = 0; i < m; i++)
                            {
                                if (indexes.Contains(i))
                                {
                                    int g = indexes.IndexOf(i);
                                    int g2 = (int)indexes2[g];
                                    str += " " + Math.Round(P0[g2], 3).ToString() + ";";
                                }
                                else str += " 0; ";
                                
                            }
                            str += " }";
                            listBox1.Items.Add(str);
                            break;
                        }
                    
                    }
                    if(deltaM.Count > 0 && max > 0 && max2 < 0)
                    {
                        if (max_or_min == "MIN")
                            listBox1.Items.Add(deltaM[0] * (-1) + " * M +(" + delta[0] * (-1) + ")");
                        else listBox1.Items.Add(deltaM[0] + " * M +(" + delta[0] + ")");
                        break;
                    }
                    if (max < 0 || max2 < 0)//якщо у одному з дельта є від'ємне то починаемо симплекс метод
                    {
                        List<double> Q = new List<double>();
                        for (int i = 0; i < X_i[i].Count; i++)//знаходимо КЬЮ (мінімальне відношення Cb/aii)
                        {
                            if (X_i[ind][i] <= 0) Q.Add(1000000000000);
                            else Q.Add(P0[i] / X_i[ind][i]);
                        }
                        int ind_q = Q.IndexOf(Q.Min());

                        double coef = X_i[ind][ind_q];//знаходимо позицію для головного числа

                        List<List<double>> X_i_new = new List<List<double>>();
                        List<double> P0_new = new List<double>(); 
                        for (int i = 0; i < X_i.Count; i++)
                        {
                            List<double> temp = new List<double>();
                            for (int j = 0; j < X_i[i].Count; j++)
                            {
                                temp.Add(X_i[i][j]);
                                if(i == 0)
                                {
                                    P0_new.Add(P0[j]);
                                }
                            }
                            X_i_new.Add(temp);
                        }
                        for (int i = 0; i < X_i.Count; i++)//робимо симплекс метод
                        {
                            for (int j = 0; j < X_i[i].Count; j++)
                            {
                                if (i == ind && j != ind_q) X_i_new[i][j] = 0;
                                else if (i != ind && j == ind_q) X_i_new[i][j] /= coef;
                                else if (i == ind && j == ind_q) X_i_new[i][j] = 1;
                                else X_i_new[i][j] = ((X_i[i][j] * coef) - (X_i[ind][j] * X_i[i][ind_q])) / coef;

                                if (i == ind)
                                {
                                    if (j == ind_q) P0_new[j] /= coef;
                                    else P0_new[j] = ((P0[j] * coef) - (P0[ind_q] * X_i[i][j])) / coef;
                                }
                            }

                        }
                        X_i.Clear();
                        P0.Clear();
                        for (int i = 0; i < X_i_new.Count; i++)
                        {
                            List<double> temp = new List<double>();
                            for (int j = 0; j < X_i_new[i].Count; j++)
                            {
                                temp.Add(X_i_new[i][j]);
                                if (i == 0)
                                {
                                    P0.Add(P0_new[j]);
                                }
                            }
                            X_i.Add(temp);
                        }
                        index.Clear();
                        index2.Clear();
                        for (int i = 0; i < X_i.Count; i++) //Починаємо рахувати кількість базисних зміних
                        {
                            int c_0 = 0, c = 0;
                            for (int j = 0; j < X_i[i].Count; j++)
                            {
                                if (X_i[i][j] < 0)
                                {
                                    if (j < X_i[i].Count - 1) break;
                                    else
                                    {
                                        c_0++;
                                        break;
                                    }
                                }
                                else
                                {
                                    if (X_i[i][j] == 0) c_0++;
                                    else if (X_i[i][j] == 1) c = j;
                                    else break;
                                }
                            }
                            if (c_0 == X_i[i].Count - 1)
                            {
                                index.Add(i);
                                index2.Add(c);
                            }
                        }
                        if(tupleM.Count > 0)
                        {
                            int c = -1;
                            for (int i = 0; i < tupleM.Count; i++)
                            {
                                
                                if (!index.Contains(tupleM[i].Item2))
                                {
                                    c = tupleM[i].Item2;
                                    X_i.RemoveAt(c);
                                    F.RemoveAt(c);
                                    index3.Remove(tupleM[i].Item1);
                                    tupleM.RemoveAt(i);
                                    break;
                                }
                            }
                            for(int i = 0; i < index.Count; i++)
                            {
                                if(c!= -1)
                                {
                                    if (index[i] > c) index[i] -= 1;
                                }
                                
                            }
                            for (int i = 0; i < tupleM.Count; i++)
                            {
                                if (c != -1)
                                {
                                    if (tupleM[i].Item2 > c)
                                    {
                                        Tuple<int, int> tuple = new Tuple<int, int>(tupleM[i].Item1, tupleM[i].Item2 - 1);
                                        tupleM[i] = tuple;
                                    }
                                        
                                }

                            }
                            //for (int i = 0; i < tupleM.Count; i++)
                            //{
                            //    if (tupleM[i].Item2 > X_i.Count - 1)
                            //    {
                            //        Tuple<int, int> tuple = new Tuple<int, int>(tupleM[i].Item1, tupleM[i].Item2 - 1);
                            //        tupleM[i] = tuple;
                            //    }
                            //}
                        }

                        if (index3.Count == 0 && delta.Skip(1).Min() >= 0 && deltaM.Count == 0)
                        {
                            if (max_or_min == "MIN")
                                listBox1.Items.Add(Math.Round(delta[0] * (-1), 3));
                            else listBox1.Items.Add(Math.Round(delta[0], 3));
                            string str = "{ ";
                            int count = 0;
                            Cb = Cb.OrderBy(cb1 => cb1.Item2).ToList();
                            List<double> indexes = new List<double>();
                            List<double> indexes2 = new List<double>();
                            for (int i = 0; i < Cb.Count; i++)
                            {
                                indexes.Add(Cb[i].Item2);
                                indexes2.Add(Cb[i].Item3);
                            }
                            for (int i = 0; i < m; i++)
                            {
                                if (indexes.Contains(i))
                                {
                                    int g = indexes.IndexOf(i);
                                    int g2 = (int)indexes2[g];
                                    str += " " + Math.Round(P0[g2], 3).ToString() + ";";
                                }
                                else str += " 0; ";

                            }
                            str += " }";
                            listBox1.Items.Add(str);
                            break;
                        }

                    }

                    else
                    {
                        if (max_or_min == "MIN")
                            listBox1.Items.Add(Math.Round(delta[0] * (-1), 3));
                        else listBox1.Items.Add(Math.Round(delta[0], 3));
                        string str = "{ ";
                        int count = 0;
                        Cb = Cb.OrderBy(cb1 => cb1.Item2).ToList();
                        List<double> indexes = new List<double>();
                        List<double> indexes2 = new List<double>();
                        for (int i = 0; i < Cb.Count; i++)
                        {
                            indexes.Add(Cb[i].Item2);
                            indexes2.Add(Cb[i].Item3);
                        }
                        for (int i = 0; i < m; i++)
                        {
                            if (indexes.Contains(i))
                            {
                                int g = indexes.IndexOf(i);
                                int g2 = (int)indexes2[g];
                                str += " " + Math.Round(P0[g2], 3).ToString() + ";";
                            }
                            else str += " 0; ";

                        }
                        str += " }";
                        listBox1.Items.Add(str);
                        break;
                    }
                    
                    if(iter > 20)
                    {
                        listBox1.Items.Add("Розв'язків немає або їх безліч");
                        break;
                    }

                } while (t == false);
            }
            else if(index.Count == baz_count)
            {
                listBox1.Items.Add("Error");
            }
        }
        private void btnCalc_Click(object sender, EventArgs e)
        {
           Calc();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateMatrix2();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            CreateMatrixTest();
        }
    }
}
