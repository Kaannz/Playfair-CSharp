using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Hill
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public string data { get; set; } // chứa chuỗi nhưng chưa có khoảng trắng
        public char[] arrForm2 { get; set; } // lưu matrix từ form 1 qua
        private List<char> arr = new List<char>(); // để tạo khoảng cách giữa 2 chữ 1 lần
        private List<char> strr = new List<char>(); //lấy chuỗi mới đã mã hóa nhưng chưa khoảng trắng
        private List<char> strr1 = new List<char>(); // lấy chuỗi mới đã mã hóa và có khoảng trắng



        private int findindex(char [] arr, char character) // tìm vị trí trong ma trận
        {
            int j = 25;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == character)
                {
                    j = i;
                }
            }
            return j;
        }

        private void adjustString(List<char> a)
        {
            for(int i = 0; i < a.Count - 1; i++)
            {
                if ( a[i] == a[i + 1])
                {
                    if (a[i] == 'X')
                        a.Insert(i + 1, 'Q');
                    else if (a[i] == 'Q')
                        a.Insert(i + 1, 'X');
                    else a.Insert(i + 1, 'X');
                }
            }

            if (a.Count % 2 == 1)
            {
                if (a[a.Count - 1] == 'X')
                    a.Add('Q');
                else a.Add('X');
            }
        }
        private void aadd(char a)
        {
            strr.Add(a);
        }
        private void encrypt()
        {
            char[] b = data.ToCharArray();
            List<char> c = new List<char>(b.Length);
            
            c.AddRange(data);
            adjustString(c);
            int indexA, indexB;
            for(int i = 0; i < c.Count; i+=2)
            {
                if( c[i] != ' ')
                {
                    indexA = findindex(arrForm2, c[i]);
                    indexB = findindex(arrForm2, c[i + 1]);
                    if(indexA % 5 == indexB % 5) // hàng dọc
                    {
                        if (indexA / 5 == 4)  // nếu nằm ô thuộc dãy ngang cuối thì chuyển lên đầu
                        {
                            aadd(arrForm2[indexA - 20]);
                        }
                        else if (indexB / 5 == 4) // nếu nằm ô thuộc dãy ngang cuối thì chuyển lên đầu
                        {
                            aadd(arrForm2[indexB - 20]);
                        }
                        else // trường hợp nằm cùng 1 hàng
                        {
                            aadd(arrForm2[indexA + 5]);
                            aadd(arrForm2[indexB + 5]);
                        }

                    }
                    else if (indexA / 5 == indexB / 5) // hàng ngang
                    {
                        if (indexA % 5 == 4) // nếu nằm ở ô thuộc dãy dọc cuối thì chuyển lên đầu
                        {
                            aadd(arrForm2[indexA - 4]);
                        }
                        else if (indexB % 5 == 4) // nếu nằm ở ô thuộc dãy dọc cuối thì chuyển lên đầu
                        {
                            aadd(arrForm2[indexB - 4]);                     
                        }
                        else // trường hợp bình thường
                        { 
                            aadd(arrForm2[indexA + 1]);
                            aadd(arrForm2[indexB + 1]);
                        }
                    }
                    else if (indexA % 5 != indexB % 5 && indexA / 5 != indexB / 5) // không cùng hàng
                    {
                            aadd(arrForm2[indexA - (indexA % 5) + (indexB % 5)]);
                            aadd(arrForm2[indexB - (indexB % 5) + (indexA % 5)]);
                    }
                }
            }

            string st1 = new string(converttochararray(c));
            List<char> d = new List<char>();
            richTextBox1.Text = splitString(st1, d);
        }

        private char [] converttochararray(List<char> strr)
        {
            char[] a = new char[strr.Count];
            for(int i = 0; i < strr.Count; i++)
            {
                a[i] = strr[i];
            }
            return a;
        }


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private string splitString(string data, List<Char> arr)
        {
            arr.AddRange(data);

            for(int i=0; i < arr.Count;i++)
            {
                if (i % 3 == 2)
                {
                    arr.Insert(i,' ');
                }
            }
            char[] a = new char[arr.Count];
            for(int i = 0; i < arr.Count; i++)
            {
                a[i] = arr[i];
            }

            string str = new string(a);
            return str;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            string str = splitString(data,arr);
            richTextBox1.Text = str;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form3 = new Form3();
            encrypt();
            string st = new string(converttochararray(strr));
            form3.stringEncrypt3 = splitString(st,strr1);
            form3.Show();
            button1.Enabled = false;
        }
    }
}
