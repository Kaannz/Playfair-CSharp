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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private char[] Alphabet = new char[25];
        private char[] arr;
        private List<char> key;
        private int length;
        private int reallength;
        private char[] encryptString;
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private int pickup(char [] arr)
        {
            key.AddRange(textBox1.Text.ToUpper().ToCharArray());
            arr = textBox1.Text.ToCharArray();
            Alphabet[0] = 'A'; Alphabet[1] = 'B'; Alphabet[2] = 'C'; Alphabet[3] = 'D'; Alphabet[4] = 'E';
            Alphabet[5] = 'F'; Alphabet[6] = 'G'; Alphabet[7] = 'H'; Alphabet[8] = 'I'; Alphabet[9] = 'K';
            Alphabet[10] = 'L'; Alphabet[11] = 'M'; Alphabet[12] = 'N'; Alphabet[13] = 'O'; Alphabet[14] = 'P';
            Alphabet[15] = 'Q'; Alphabet[16] = 'R'; Alphabet[17] = 'S'; Alphabet[18] = 'T'; Alphabet[19] = 'U';
            Alphabet[20] = 'V'; Alphabet[21] = 'W'; Alphabet[22] = 'X'; Alphabet[23] = 'Y'; Alphabet[24] = 'Z';
            return arr.Length;
        }

        private int optimizekey(char[] arr, List<char> str, int length)
        {

            int n = length;
            List<char> str1 = str;
            for (int i = 0; i < n; i++)
            {
                if (str[i] == 'J')
                {
                    str[i] = 'I';
                }
            }
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (str[i] == str1[j])
                    {
                        key.RemoveAt(j);
                        n--;
                        j--;
                    }
                }
            }

            length = key.Count;
            for (int i=0; i < length;i++)
            {
                arr[i] = key[i];
            }
            return length;
        }

        private void createMatrix(char[] arr,List <char> str, int length)
        {
            //arr là chuỗi rỗng với phần đầu là key
            //str là chuỗi key
            //length là độ dài của key
            //Alphabet là bản ký tự 

            int n = optimizekey(arr, str, length);
            length = n;
            for (int i = 0; i < 25; i++)
            {
                for(int j = 0; j < length; j++)
                {
                    // so sánh chuỗi key với 1 chữ cái alphabet
                    if (Alphabet[i] == str[j]) // trùng thì không làm gì và tăng tiếp
                    {
                        i++; //có ký tự trùng thì alpha tăng lên chữ tiếp theo
                        j = 0; // đồng thời gán j = 0  để so sánh lại chuỗi key
                    }
                        // không trùng thì gán ký tự đó của alpha vào chuỗi đó 

                }
                arr[n] = Alphabet[i];
                n++;

            }
        }

        private void showMatrix()
        {
            textBox2.Text = arr[0].ToString();
            textBox3.Text = arr[1].ToString();
            textBox4.Text = arr[2].ToString();
            textBox5.Text = arr[3].ToString();
            textBox6.Text = arr[4].ToString();
            textBox7.Text = arr[5].ToString();
            textBox8.Text = arr[6].ToString();
            textBox9.Text = arr[7].ToString();
            textBox10.Text = arr[8].ToString();
            textBox11.Text = arr[9].ToString();
            textBox12.Text = arr[10].ToString();
            textBox13.Text = arr[11].ToString();
            textBox14.Text = arr[12].ToString();
            textBox15.Text = arr[13].ToString();
            textBox16.Text = arr[14].ToString();
            textBox17.Text = arr[15].ToString();
            textBox18.Text = arr[16].ToString();
            textBox19.Text = arr[17].ToString();
            textBox20.Text = arr[18].ToString();
            textBox21.Text = arr[19].ToString();
            textBox22.Text = arr[20].ToString();
            textBox23.Text = arr[21].ToString();
            textBox24.Text = arr[22].ToString();
            textBox25.Text = arr[23].ToString();
            textBox26.Text = arr[24].ToString();
        }

        private void delete()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
            textBox19.Text = "";
            textBox20.Text = "";
            textBox21.Text = "";
            textBox22.Text = "";
            textBox23.Text = "";
            textBox24.Text = "";
            textBox25.Text = "";
            textBox26.Text = "";
        }

        private string getstring()
        {
            string s = textBox27.Text;
            s = s.Replace(" ", "").ToUpper();
            return s;

        }

        private int checkString(string s)
        {

            char[] a = new char[s.Length];
            a= s.ToCharArray();
            for( int i = 0; i < a.Length; i++)
            {
                if (Char.IsNumber(a[i]) == true)
                {
                    return 0;
                }
            }
            return 1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                arr = new char[25];
                key = new List<char>();
                reallength = pickup(arr);
                createMatrix(arr, key, reallength);
                showMatrix();
                button1.Enabled = false;
                
            }
            else MessageBox.Show("Key is still empty, please enter!");

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private string addx(string s)
        {
            char[] a = s.ToCharArray();
            
            int n = a.Length;
            if (n % 2 == 1)
            {
                char[] b = new char[n+1];
                for(int i = 0; i < n; i++)
                {
                    b[i] = a[i];
                }
                b[n] = 'X';
                string s1 = new string(b);
                return s1;
            }
            return s;
        }

        private int checkMatrix(char[] arr)
        {
            if (arr == null)
                return 0;
            for(int i = 0; i < arr.Length; i++)
            {
                if(arr[i] == ' ')
                {
                    return 0;
                }
            }
            return 1;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string s = getstring();
            int a = checkString(s);
            int b = checkMatrix(arr);
            if (a == 1 && b == 1)
            {
                //label3.Text = s;
                var form2 = new Form2();
                s = addx(s);
                form2.data = s;
                form2.arrForm2 = arr;
                form2.Show();
                var form3 = new Form3();
            }
            else if (a == 0) MessageBox.Show("Do not enter with number");
            else MessageBox.Show("You must enter key and press enter");
        }


        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox27.Text = "";
            button1.Enabled = true;
            delete();

        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
