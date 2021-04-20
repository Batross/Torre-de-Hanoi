using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Variables
        bool cargada =false;
        int tomador = 0;
        int intentos = 0;        
		int Tnumeros = 0;
        int contadorNodosC = 0;
        Nodo UltimoJugado = null;
        Nodo TomadorA = null;
        Nodo TomadorB = null;
        Nodo TomadorC = null;
        Nodo [] ArrayNodos = new Nodo [3];
        string copia1, copia2, copia3;
        Pila A = new Pila ();
        Pila B = new Pila();
        Pila C = new Pila();
        #endregion
        
        private void Form1_Load(object sender, EventArgs e)
        {
            Fichas(Tnumeros);
        }

        #region Clases
        public class Nodo
        {
            public int Valor { get; set; }
            public Nodo Anterior { get; set; }
        }

        public class Pila
        {
            private Nodo Ultimo;
            public Pila()
            {
                Ultimo = null;
            }
            public void Apilar()
            {
                if(Ultimo==null)
                {
                     Ultimo = new Nodo() {Anterior = null };
                }
                else
                {
                     Ultimo = new Nodo() {Anterior = Ultimo };
                }
            }
            public void Desapilar()
            {
                if(Ultimo!=null)
                {
                    Ultimo = Ultimo.Anterior;
                }
            }
            public Nodo Ver()
            {
                return Ultimo;
            }
            int contadorNodosGeneral = 0;
            public int RetornaTnodos(Nodo pnodo)
            {
                if(pnodo!=null)
                {
                    contadorNodosGeneral++;
                    return RetornaTnodos(pnodo.Anterior);
                }
                int resultado = contadorNodosGeneral;
                contadorNodosGeneral = 0;
                return resultado;
            }
        }
        #endregion

        #region Eventos textbox
            #region TextChanged
            private void textBox1_TextChanged(object sender, EventArgs e)
            {
                if(cargada==true)
                {
                    textBox1.Text = copia1;
                    MessageBox.Show("No puede quitar piezas que estan por debajo de otras");
                }
            }

            private void textBox2_TextChanged(object sender, EventArgs e)
            {
                if (cargada == true)
                {
                    textBox2.Text = copia2;
                    MessageBox.Show("No puede quitar piezas que estan por debajo de otras");
                }
            }

            private void textBox3_TextChanged(object sender, EventArgs e)
            {
                if (cargada == true)
                {
                    textBox3.Text = copia3;
                    MessageBox.Show("No puede quitar piezas que estan por debajo de otras");
                }
            }

        #endregion
        #region Click
        private void textBox1_Click(object sender, EventArgs e)
        {
            if (tomador == 0)
            {
                cargada = false;
                try
                {
                    tomador = A.Ver().Valor;
                    A.Desapilar();
                    textBox1.Clear();
                    MostrarA(A.Ver());
                    copia1 = textBox1.Text;
                    label4.Text = "Valor tomado: " + tomador.ToString();
                }
                catch (Exception) { }
                cargada = true;
            }
            else
            {
                cargada = false;
                if (A.Ver() != null)
                {
                    if (!(tomador > A.Ver().Valor))
                    {
                        A.Apilar();
                        A.Ver().Valor = tomador;
                        tomador = 0;
                        UltimoJugado = A.Ver();
                        textBox1.Clear();
                        MostrarA(A.Ver());
                        copia1 = textBox1.Text;
                        label4.Text = "Valor tomado: ";
                        intentos++;
                        label5.Text = "Intentos: " + intentos;
                    }
                    else
                    {
                        MessageBox.Show("No se puede colocar un valor mayor sobre otro menor");
                    }
                    cargada = true;
                }
                else
                {
                    A.Apilar();
                    A.Ver().Valor = tomador;
                    tomador = 0;
                    UltimoJugado = A.Ver();
                    textBox1.Clear();
                    MostrarA(A.Ver());
                    copia1 = textBox1.Text;
                    label4.Text = "Valor tomado: ";
                    intentos++;
                    label5.Text = "Intentos: " + intentos;
                    cargada = true;
                }
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (tomador == 0)
            {
                cargada = false;
                try
                {
                    tomador = B.Ver().Valor;
                    B.Desapilar();
                    textBox2.Clear();
                    MostrarB(B.Ver());
                    copia2 = textBox2.Text;
                    label4.Text = "Valor tomado: " + tomador.ToString();
                }
                catch (Exception) { }
                cargada = true;
            }
            else
            {
                cargada = false;
                if (B.Ver() != null)
                {
                    if (!(tomador > B.Ver().Valor))
                    {
                        B.Apilar();
                        B.Ver().Valor = tomador;
                        tomador = 0;
                        UltimoJugado = B.Ver();
                        textBox2.Clear();
                        MostrarB(B.Ver());
                        copia2 = textBox2.Text;
                        label4.Text = "Valor tomado: ";
                        intentos++;
                        label5.Text = "Intentos: " + intentos;
                    }
                    else
                    {
                        MessageBox.Show("No se puede colocar un valor mayor sobre otro menor");
                    }
                    cargada = true;
                }
                else
                {
                    B.Apilar();
                    B.Ver().Valor = tomador;
                    tomador = 0;
                    UltimoJugado = B.Ver();
                    textBox2.Clear();
                    MostrarB(B.Ver());
                    copia2 = textBox2.Text;
                    cargada = true;
                    label4.Text = "Valor tomado: ";
                    intentos++;
                    label5.Text = "Intentos: " + intentos;
                }
            }
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            if (tomador == 0)
            {
                cargada = false;
                try
                {
                    tomador = C.Ver().Valor;
                    C.Desapilar();
                    textBox3.Clear();
                    MostrarC(C.Ver());
                    copia3 = textBox3.Text;
                    label4.Text = "Valor tomado: " + tomador.ToString();
                    contadorNodosC--;
                }
                catch (Exception) { }
                cargada = true;
            }
            else
            {
                cargada = false;
                if (C.Ver() != null)
                {
                    if (!(tomador > C.Ver().Valor))
                    {
                        C.Apilar();
                        C.Ver().Valor = tomador;
                        tomador = 0;
                        UltimoJugado = C.Ver();
                        textBox3.Clear();
                        MostrarC(C.Ver());
                        copia3 = textBox3.Text;
                        label4.Text = "Valor tomado: ";
                        intentos++;
                        label5.Text = "Intentos: " + intentos;
                        contadorNodosC++;
                    }
                    else
                    {
                        MessageBox.Show("No se puede colocar un valor mayor sobre otro menor");
                    }
                    cargada = true;
                }
                else
                {
                    C.Apilar();
                    C.Ver().Valor = tomador;
                    tomador = 0;
                    UltimoJugado = C.Ver();
                    textBox3.Clear();
                    MostrarC(C.Ver());
                    copia3 = textBox3.Text;
                    cargada = true;
                    label4.Text = "Valor tomado: ";
                    intentos++;
                    label5.Text = "Intentos: " + intentos;
                    contadorNodosC++;
                }
            }
            if (contadorNodosC == Tnumeros && Tnumeros != 0)
            {
                MessageBox.Show("GANASTE!!!");
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
            }
        }
        #endregion
        #endregion

        #region Botones
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
            if(button2.Text=="Activar \"Juego automático\"")
            {
                button2.Text = "Pausar";
            }
            else { button2.Text = "Activar \"Juego automático\""; }
            if(timer1.Enabled==true)
            {
                label6.Enabled = true;
                hScrollBar1.Enabled = true;
            }
            else
            {
                label6.Enabled = false;
                hScrollBar1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cargada = false;
            DesapilarTodo(A.Ver(), A);
            DesapilarTodo(B.Ver(), B);
            DesapilarTodo(C.Ver(), C);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            tomador = 0;
            for (int cont1 = Tnumeros; cont1 >= 1; cont1--)
            {
                A.Apilar();
                A.Ver().Valor = cont1;
            }
            MostrarA(A.Ver());
            copia1 = textBox1.Text;
            copia2 = textBox2.Text;
            copia3 = textBox3.Text;
            label4.Text = "Valor tomado: ";
            intentos = 0;
            label5.Text = "Intentos: " + intentos;
            contadorNodosC = 0;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            if(timer1.Enabled==true)
            {
                timer1.Enabled = false;
                button2.Text = "Activar \"Juego automático\"";
                label6.Enabled = false;
                hScrollBar1.Enabled = false;
            }
            button2.Enabled = true;
            cargada = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Tnumeros = int.Parse(Interaction.InputBox("Ingrese cantidad de números"));
            }
            catch (Exception)
            {
                Tnumeros = 0;
            }
            
            Fichas(Tnumeros);
        }
        #endregion

        #region Otros eventos
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (A.Ver() != null && B.Ver() != null && C.Ver() != null)
            {
                TomadorA = A.Ver();
                TomadorB = B.Ver();
                TomadorC = C.Ver();
                ArrayNodos[0] = TomadorA;
                ArrayNodos[1] = TomadorB;
                ArrayNodos[2] = TomadorC;
                Nodo aux;
                for (int cont = 0; cont < 3; cont++)
                {
                    for (int cont2 = cont; cont2 < 3; cont2++)
                    {
                        if (ArrayNodos[cont2].Valor < ArrayNodos[cont].Valor)
                        {
                            aux = ArrayNodos[cont2];
                            ArrayNodos[cont2] = ArrayNodos[cont];
                            ArrayNodos[cont] = aux;
                        }
                    }
                }
                if (UltimoJugado.Valor == 1)
                {
                    if (ArrayNodos[1].Valor == A.Ver().Valor)
                    {
                        cargada = false;
                        tomador = A.Ver().Valor;
                        UltimoJugado = A.Ver();
                        A.Desapilar();
                        textBox1.Clear();
                        MostrarA(A.Ver());
                        copia1 = textBox1.Text;
                        label4.Text = "Valor tomado: " + tomador.ToString();
                        if (B.Ver().Valor != 1)
                        {
                            B.Apilar();
                            B.Ver().Valor = tomador;
                            tomador = 0;
                            textBox2.Clear();
                            MostrarB(B.Ver());
                            copia2 = textBox2.Text;
                            label4.Text = "Valor tomado: ";
                            intentos++;
                            label5.Text = "Intentos: " + intentos;
                        }
                        else
                        {
                            C.Apilar();
                            C.Ver().Valor = tomador;
                            tomador = 0;
                            textBox3.Clear();
                            MostrarC(C.Ver());
                            copia3 = textBox3.Text;
                            label4.Text = "Valor tomado: ";
                            intentos++;
                            label5.Text = "Intentos: " + intentos;
                            contadorNodosC++;
                        }
                        cargada = true;
                    }
                    else if (ArrayNodos[1].Valor == B.Ver().Valor)
                    {
                        cargada = false;
                        tomador = B.Ver().Valor;
                        UltimoJugado = B.Ver();
                        B.Desapilar();
                        textBox2.Clear();
                        MostrarB(B.Ver());
                        copia2 = textBox2.Text;
                        label4.Text = "Valor tomado: " + tomador.ToString();
                        if (A.Ver().Valor != 1)
                        {
                            A.Apilar();
                            A.Ver().Valor = tomador;
                            tomador = 0;
                            textBox1.Clear();
                            MostrarA(A.Ver());
                            copia1 = textBox1.Text;
                            label4.Text = "Valor tomado: ";
                            intentos++;
                            label5.Text = "Intentos: " + intentos;
                        }
                        else
                        {
                            C.Apilar();
                            C.Ver().Valor = tomador;
                            tomador = 0;
                            textBox3.Clear();
                            MostrarC(C.Ver());
                            copia3 = textBox3.Text;
                            label4.Text = "Valor tomado: ";
                            intentos++;
                            label5.Text = "Intentos: " + intentos;
                            contadorNodosC++;
                        }
                        cargada = true;
                    }
                    else if (ArrayNodos[1].Valor == C.Ver().Valor)
                    {
                        cargada = false;
                        tomador = C.Ver().Valor;
                        UltimoJugado = C.Ver();
                        C.Desapilar();
                        textBox3.Clear();
                        MostrarC(C.Ver());
                        copia3 = textBox3.Text;
                        label4.Text = "Valor tomado: " + tomador.ToString();
                        contadorNodosC--;
                        if (B.Ver().Valor != 1)
                        {
                            B.Apilar();
                            B.Ver().Valor = tomador;
                            tomador = 0;
                            textBox2.Clear();
                            MostrarB(B.Ver());
                            copia2 = textBox2.Text;
                            label4.Text = "Valor tomado: ";
                            intentos++;
                            label5.Text = "Intentos: " + intentos;
                        }
                        else
                        {
                            A.Apilar();
                            A.Ver().Valor = tomador;
                            tomador = 0;
                            textBox1.Clear();
                            MostrarA(A.Ver());
                            copia1 = textBox1.Text;
                            label4.Text = "Valor tomado: ";
                            intentos++;
                            label5.Text = "Intentos: " + intentos;
                        }
                        cargada = true;
                    }
                }
                else
                {
                    if (A.Ver().Valor == 1)
                    {
                        if ((A.Ver().Anterior != null) && (A.Ver().Anterior.Valor == 2))
                        {
                            if (B.Ver().Valor % 2 == 0 && C.Ver().Valor % 2 != 0)
                            {
                                cargada = false;
                                tomador = A.Ver().Valor;
                                UltimoJugado = A.Ver();
                                A.Desapilar();
                                textBox1.Clear();
                                MostrarA(A.Ver());
                                copia1 = textBox1.Text;
                                label4.Text = "Valor tomado: " + tomador.ToString();
                                B.Apilar();
                                B.Ver().Valor = tomador;
                                tomador = 0;
                                textBox2.Clear();
                                MostrarB(B.Ver());
                                copia2 = textBox2.Text;
                                label4.Text = "Valor tomado: ";
                                intentos++;
                                label5.Text = "Intentos: " + intentos;
                                cargada = true;
                            }
                            else if (C.Ver().Valor % 2 == 0 && B.Ver().Valor % 2 != 0)
                            {
                                cargada = false;
                                tomador = A.Ver().Valor;
                                UltimoJugado = A.Ver();
                                A.Desapilar();
                                textBox1.Clear();
                                MostrarA(A.Ver());
                                copia1 = textBox1.Text;
                                label4.Text = "Valor tomado: " + tomador.ToString();
                                C.Apilar();
                                C.Ver().Valor = tomador;
                                tomador = 0;
                                textBox3.Clear();
                                MostrarC(C.Ver());
                                copia3 = textBox3.Text;
                                label4.Text = "Valor tomado: ";
                                intentos++;
                                label5.Text = "Intentos: " + intentos;
                                contadorNodosC++;
                                cargada = true;
                            }
                            else if (B.Ver().Valor % 2 == 0 && C.Ver().Valor % 2 == 0)
                            {
                                if (B.Ver().Valor < C.Ver().Valor)
                                {
                                    cargada = false;
                                    tomador = A.Ver().Valor;
                                    UltimoJugado = A.Ver();
                                    A.Desapilar();
                                    textBox1.Clear();
                                    MostrarA(A.Ver());
                                    copia1 = textBox1.Text;
                                    label4.Text = "Valor tomado: " + tomador.ToString();
                                    B.Apilar();
                                    B.Ver().Valor = tomador;
                                    tomador = 0;
                                    textBox2.Clear();
                                    MostrarB(B.Ver());
                                    copia2 = textBox2.Text;
                                    label4.Text = "Valor tomado: ";
                                    intentos++;
                                    label5.Text = "Intentos: " + intentos;
                                    cargada = true;
                                }
                                else
                                {
                                    cargada = false;
                                    tomador = A.Ver().Valor;
                                    UltimoJugado = A.Ver();
                                    A.Desapilar();
                                    textBox1.Clear();
                                    MostrarA(A.Ver());
                                    copia1 = textBox1.Text;
                                    label4.Text = "Valor tomado: " + tomador.ToString();
                                    C.Apilar();
                                    C.Ver().Valor = tomador;
                                    tomador = 0;
                                    textBox3.Clear();
                                    MostrarC(C.Ver());
                                    copia3 = textBox3.Text;
                                    label4.Text = "Valor tomado: ";
                                    intentos++;
                                    label5.Text = "Intentos: " + intentos;
                                    contadorNodosC++;
                                    cargada = true;
                                }
                            }
                        }
                        else
                        {
                            if (B.Ver().Valor == 2)
                            {
                                cargada = false;
                                tomador = A.Ver().Valor;
                                UltimoJugado = A.Ver();
                                A.Desapilar();
                                textBox1.Clear();
                                MostrarA(A.Ver());
                                copia1 = textBox1.Text;
                                label4.Text = "Valor tomado: " + tomador.ToString();
                                B.Apilar();
                                B.Ver().Valor = tomador;
                                tomador = 0;
                                textBox2.Clear();
                                MostrarB(B.Ver());
                                copia2 = textBox2.Text;
                                label4.Text = "Valor tomado: ";
                                intentos++;
                                label5.Text = "Intentos: " + intentos;
                                cargada = true;
                            }
                            else if (C.Ver().Valor == 2)
                            {
                                cargada = false;
                                tomador = A.Ver().Valor;
                                UltimoJugado = A.Ver();
                                A.Desapilar();
                                textBox1.Clear();
                                MostrarA(A.Ver());
                                copia1 = textBox1.Text;
                                label4.Text = "Valor tomado: " + tomador.ToString();
                                C.Apilar();
                                C.Ver().Valor = tomador;
                                tomador = 0;
                                textBox3.Clear();
                                MostrarC(C.Ver());
                                copia3 = textBox3.Text;
                                label4.Text = "Valor tomado: ";
                                intentos++;
                                label5.Text = "Intentos: " + intentos;
                                contadorNodosC++;
                                cargada = true;
                            }
                        }
                    }
                    else if (B.Ver().Valor == 1)
                    {
                        if ((B.Ver().Anterior != null) && (B.Ver().Anterior.Valor == 2))
                        {
                            if (A.Ver().Valor % 2 == 0 && C.Ver().Valor % 2 != 0)
                            {
                                cargada = false;
                                tomador = B.Ver().Valor;
                                UltimoJugado = B.Ver();
                                B.Desapilar();
                                textBox2.Clear();
                                MostrarB(B.Ver());
                                copia2 = textBox2.Text;
                                label4.Text = "Valor tomado: " + tomador.ToString();
                                A.Apilar();
                                A.Ver().Valor = tomador;
                                tomador = 0;
                                textBox1.Clear();
                                MostrarA(A.Ver());
                                copia1 = textBox1.Text;
                                label4.Text = "Valor tomado: ";
                                intentos++;
                                label5.Text = "Intentos: " + intentos;
                                cargada = true;
                            }
                            else if (C.Ver().Valor % 2 == 0 && A.Ver().Valor % 2 != 0)
                            {
                                cargada = false;
                                tomador = B.Ver().Valor;
                                UltimoJugado = B.Ver();
                                B.Desapilar();
                                textBox2.Clear();
                                MostrarB(B.Ver());
                                copia2 = textBox2.Text;
                                label4.Text = "Valor tomado: " + tomador.ToString();
                                C.Apilar();
                                C.Ver().Valor = tomador;
                                tomador = 0;
                                textBox3.Clear();
                                MostrarC(C.Ver());
                                copia3 = textBox3.Text;
                                label4.Text = "Valor tomado: ";
                                intentos++;
                                label5.Text = "Intentos: " + intentos;
                                contadorNodosC++;
                                cargada = true;
                            }
                            else if (A.Ver().Valor % 2 == 0 && C.Ver().Valor % 2 == 0)
                            {
                                if (A.Ver().Valor < C.Ver().Valor)
                                {
                                    cargada = false;
                                    tomador = B.Ver().Valor;
                                    UltimoJugado = B.Ver();
                                    B.Desapilar();
                                    textBox2.Clear();
                                    MostrarB(B.Ver());
                                    copia2 = textBox2.Text;
                                    label4.Text = "Valor tomado: " + tomador.ToString();
                                    A.Apilar();
                                    A.Ver().Valor = tomador;
                                    tomador = 0;
                                    textBox1.Clear();
                                    MostrarA(A.Ver());
                                    copia1 = textBox1.Text;
                                    label4.Text = "Valor tomado: ";
                                    intentos++;
                                    label5.Text = "Intentos: " + intentos;
                                    cargada = true;
                                }
                                else
                                {
                                    cargada = false;
                                    tomador = B.Ver().Valor;
                                    UltimoJugado = B.Ver();
                                    B.Desapilar();
                                    textBox2.Clear();
                                    MostrarB(B.Ver());
                                    copia2 = textBox2.Text;
                                    label4.Text = "Valor tomado: " + tomador.ToString();
                                    C.Apilar();
                                    C.Ver().Valor = tomador;
                                    tomador = 0;
                                    textBox3.Clear();
                                    MostrarC(C.Ver());
                                    copia3 = textBox3.Text;
                                    label4.Text = "Valor tomado: ";
                                    intentos++;
                                    label5.Text = "Intentos: " + intentos;
                                    contadorNodosC++;
                                    cargada = true;
                                }
                            }
                        }
                        else
                        {
                            if (A.Ver().Valor == 2)
                            {
                                cargada = false;
                                tomador = B.Ver().Valor;
                                UltimoJugado = B.Ver();
                                B.Desapilar();
                                textBox2.Clear();
                                MostrarB(B.Ver());
                                copia2 = textBox2.Text;
                                label4.Text = "Valor tomado: " + tomador.ToString();
                                A.Apilar();
                                A.Ver().Valor = tomador;
                                tomador = 0;
                                textBox1.Clear();
                                MostrarA(A.Ver());
                                copia1 = textBox1.Text;
                                label4.Text = "Valor tomado: ";
                                intentos++;
                                label5.Text = "Intentos: " + intentos;
                                cargada = true;
                            }
                            else if (C.Ver().Valor == 2)
                            {
                                cargada = false;
                                tomador = B.Ver().Valor;
                                UltimoJugado = B.Ver();
                                B.Desapilar();
                                textBox2.Clear();
                                MostrarB(B.Ver());
                                copia2 = textBox2.Text;
                                label4.Text = "Valor tomado: " + tomador.ToString();
                                C.Apilar();
                                C.Ver().Valor = tomador;
                                tomador = 0;
                                textBox3.Clear();
                                MostrarC(C.Ver());
                                copia3 = textBox3.Text;
                                label4.Text = "Valor tomado: ";
                                intentos++;
                                label5.Text = "Intentos: " + intentos;
                                contadorNodosC++;
                                cargada = true;
                            }
                        }
                    }
                    else if (C.Ver().Valor == 1)
                    {
                        if ((C.Ver().Anterior != null) && (C.Ver().Anterior.Valor == 2))
                        {
                            if (A.Ver().Valor % 2 == 0 && B.Ver().Valor % 2 != 0)
                            {
                                cargada = false;
                                tomador = C.Ver().Valor;
                                UltimoJugado = C.Ver();
                                C.Desapilar();
                                textBox3.Clear();
                                MostrarC(C.Ver());
                                copia3 = textBox3.Text;
                                label4.Text = "Valor tomado: " + tomador.ToString();
                                contadorNodosC--;
                                A.Apilar();
                                A.Ver().Valor = tomador;
                                tomador = 0;
                                textBox1.Clear();
                                MostrarA(A.Ver());
                                copia1 = textBox1.Text;
                                label4.Text = "Valor tomado: ";
                                intentos++;
                                label5.Text = "Intentos: " + intentos;
                                cargada = true;
                            }
                            else if (B.Ver().Valor % 2 == 0 && A.Ver().Valor % 2 != 0)
                            {
                                cargada = false;
                                tomador = C.Ver().Valor;
                                UltimoJugado = C.Ver();
                                C.Desapilar();
                                textBox3.Clear();
                                MostrarC(C.Ver());
                                copia3 = textBox3.Text;
                                label4.Text = "Valor tomado: " + tomador.ToString();
                                contadorNodosC--;
                                B.Apilar();
                                B.Ver().Valor = tomador;
                                tomador = 0;
                                textBox2.Clear();
                                MostrarB(B.Ver());
                                copia2 = textBox2.Text;
                                label4.Text = "Valor tomado: ";
                                intentos++;
                                label5.Text = "Intentos: " + intentos;
                                cargada = true;
                            }
                            else if (A.Ver().Valor % 2 == 0 && B.Ver().Valor % 2 == 0)
                            {
                                if (A.Ver().Valor < B.Ver().Valor)
                                {
                                    cargada = false;
                                    tomador = C.Ver().Valor;
                                    UltimoJugado = C.Ver();
                                    C.Desapilar();
                                    textBox3.Clear();
                                    MostrarC(C.Ver());
                                    copia3 = textBox3.Text;
                                    label4.Text = "Valor tomado: " + tomador.ToString();
                                    contadorNodosC--;
                                    A.Apilar();
                                    A.Ver().Valor = tomador;
                                    tomador = 0;
                                    textBox1.Clear();
                                    MostrarA(A.Ver());
                                    copia1 = textBox1.Text;
                                    label4.Text = "Valor tomado: ";
                                    intentos++;
                                    label5.Text = "Intentos: " + intentos;
                                    cargada = true;
                                }
                                else
                                {
                                    cargada = false;
                                    tomador = C.Ver().Valor;
                                    UltimoJugado = C.Ver();
                                    C.Desapilar();
                                    textBox3.Clear();
                                    MostrarC(C.Ver());
                                    copia3 = textBox3.Text;
                                    label4.Text = "Valor tomado: " + tomador.ToString();
                                    contadorNodosC--;
                                    B.Apilar();
                                    B.Ver().Valor = tomador;
                                    tomador = 0;
                                    textBox2.Clear();
                                    MostrarB(B.Ver());
                                    copia2 = textBox2.Text;
                                    label4.Text = "Valor tomado: ";
                                    intentos++;
                                    label5.Text = "Intentos: " + intentos;
                                    cargada = true;
                                }
                            }
                        }
                        else
                        {
                            if (A.Ver().Valor == 2)
                            {
                                cargada = false;
                                tomador = C.Ver().Valor;
                                UltimoJugado = C.Ver();
                                C.Desapilar();
                                textBox3.Clear();
                                MostrarC(C.Ver());
                                copia3 = textBox3.Text;
                                label4.Text = "Valor tomado: " + tomador.ToString();
                                contadorNodosC--;
                                A.Apilar();
                                A.Ver().Valor = tomador;
                                tomador = 0;
                                textBox1.Clear();
                                MostrarA(A.Ver());
                                copia1 = textBox1.Text;
                                label4.Text = "Valor tomado: ";
                                intentos++;
                                label5.Text = "Intentos: " + intentos;
                                cargada = true;
                            }
                            else if (B.Ver().Valor == 2)
                            {
                                cargada = false;
                                tomador = C.Ver().Valor;
                                UltimoJugado = C.Ver();
                                C.Desapilar();
                                textBox3.Clear();
                                MostrarC(C.Ver());
                                copia3 = textBox3.Text;
                                label4.Text = "Valor tomado: " + tomador.ToString();
                                contadorNodosC--;
                                B.Apilar();
                                B.Ver().Valor = tomador;
                                tomador = 0;
                                textBox2.Clear();
                                MostrarB(B.Ver());
                                copia2 = textBox2.Text;
                                label4.Text = "Valor tomado: ";
                                intentos++;
                                label5.Text = "Intentos: " + intentos;
                                cargada = true;
                            }
                        }
                    }
                }
            }

            else if (A.Ver() != null && B.Ver() == null && C.Ver() == null)
            {
                if (Tnumeros % 2 != 0)
                {
                    #region Des A - Ap C
                    cargada = false;
                    tomador = A.Ver().Valor;
                    UltimoJugado = A.Ver();
                    A.Desapilar();
                    textBox1.Clear();
                    MostrarA(A.Ver());
                    copia1 = textBox1.Text;
                    label4.Text = "Valor tomado: " + tomador.ToString();
                    C.Apilar();
                    C.Ver().Valor = tomador;
                    tomador = 0;
                    textBox3.Clear();
                    MostrarC(C.Ver());
                    copia3 = textBox3.Text;
                    label4.Text = "Valor tomado: ";
                    intentos++;
                    label5.Text = "Intentos: " + intentos;
                    contadorNodosC++;
                    cargada = true;
                    #endregion
                }
                else
                {
                    #region Des A - Ap B
                    cargada = false;
                    tomador = A.Ver().Valor;
                    UltimoJugado = A.Ver();
                    A.Desapilar();
                    textBox1.Clear();
                    MostrarA(A.Ver());
                    copia1 = textBox1.Text;
                    label4.Text = "Valor tomado: " + tomador.ToString();
                    B.Apilar();
                    B.Ver().Valor = tomador;
                    tomador = 0;
                    textBox2.Clear();
                    MostrarB(B.Ver());
                    copia2 = textBox2.Text;
                    label4.Text = "Valor tomado: ";
                    intentos++;
                    label5.Text = "Intentos: " + intentos;
                    cargada = true;
                    #endregion
                }
            }

            else if (A.Ver() == null && B.Ver() != null && C.Ver() == null)
            {
                cargada = false;
                tomador = B.Ver().Valor;
                UltimoJugado = B.Ver();
                B.Desapilar();
                textBox2.Clear();
                MostrarB(B.Ver());
                copia2 = textBox2.Text;
                label4.Text = "Valor tomado: " + tomador.ToString();
                A.Apilar();
                A.Ver().Valor = tomador;
                tomador = 0;
                textBox1.Clear();
                MostrarA(A.Ver());
                copia1 = textBox1.Text;
                label4.Text = "Valor tomado: ";
                intentos++;
                label5.Text = "Intentos: " + intentos;
                cargada = true;
            }


            else if (A.Ver() != null && B.Ver() != null && C.Ver() == null)
            {
                if (UltimoJugado.Valor == 1)
                {
                    if (A.Ver().Valor % 2 != 0 && A.Ver().Valor != 1)
                    {
                        #region Des A - Ap C
                        cargada = false;
                        tomador = A.Ver().Valor;
                        UltimoJugado = A.Ver();
                        A.Desapilar();
                        textBox1.Clear();
                        MostrarA(A.Ver());
                        copia1 = textBox1.Text;
                        label4.Text = "Valor tomado: " + tomador.ToString();
                        C.Apilar();
                        C.Ver().Valor = tomador;
                        tomador = 0;
                        textBox3.Clear();
                        MostrarC(C.Ver());
                        copia3 = textBox3.Text;
                        label4.Text = "Valor tomado: ";
                        intentos++;
                        label5.Text = "Intentos: " + intentos;
                        contadorNodosC++;
                        cargada = true;
                        #endregion
                    }
                    else if (A.Ver().Valor == 1)
                    {
                        #region Des B - Ap C
                        cargada = false;
                        tomador = B.Ver().Valor;
                        UltimoJugado = B.Ver();
                        B.Desapilar();
                        textBox2.Clear();
                        MostrarB(B.Ver());
                        copia2 = textBox2.Text;
                        label4.Text = "Valor tomado: " + tomador.ToString();
                        C.Apilar();
                        C.Ver().Valor = tomador;
                        tomador = 0;
                        textBox3.Clear();
                        MostrarC(C.Ver());
                        copia3 = textBox3.Text;
                        label4.Text = "Valor tomado: ";
                        intentos++;
                        label5.Text = "Intentos: " + intentos;
                        contadorNodosC++;
                        cargada = true;
                        #endregion
                    }
                    else if (A.Ver().Valor % 2 == 0)
                    {
                        #region Des A - Ap C
                        cargada = false;
                        tomador = A.Ver().Valor;
                        UltimoJugado = A.Ver();
                        A.Desapilar();
                        textBox1.Clear();
                        MostrarA(A.Ver());
                        copia1 = textBox1.Text;
                        label4.Text = "Valor tomado: " + tomador.ToString();
                        C.Apilar();
                        C.Ver().Valor = tomador;
                        tomador = 0;
                        textBox3.Clear();
                        MostrarC(C.Ver());
                        copia3 = textBox3.Text;
                        label4.Text = "Valor tomado: ";
                        intentos++;
                        label5.Text = "Intentos: " + intentos;
                        contadorNodosC++;
                        cargada = true;
                        #endregion
                    }
                }
                else
                {
                    if (A.Ver().Valor == 1)
                    {
                        if (B.Ver().Valor % 2 == 0)
                        {
                            #region Des A - Ap B
                            cargada = false;
                            tomador = A.Ver().Valor;
                            UltimoJugado = A.Ver();
                            A.Desapilar();
                            textBox1.Clear();
                            MostrarA(A.Ver());
                            copia1 = textBox1.Text;
                            label4.Text = "Valor tomado: " + tomador.ToString();
                            B.Apilar();
                            B.Ver().Valor = tomador;
                            tomador = 0;
                            textBox2.Clear();
                            MostrarB(B.Ver());
                            copia2 = textBox2.Text;
                            label4.Text = "Valor tomado: ";
                            intentos++;
                            label5.Text = "Intentos: " + intentos;
                            cargada = true;
                            #endregion
                        }
                        else
                        {
                            #region Des A - Ap C
                            cargada = false;
                            tomador = A.Ver().Valor;
                            UltimoJugado = A.Ver();
                            A.Desapilar();
                            textBox1.Clear();
                            MostrarA(A.Ver());
                            copia1 = textBox1.Text;
                            label4.Text = "Valor tomado: " + tomador.ToString();
                            C.Apilar();
                            C.Ver().Valor = tomador;
                            tomador = 0;
                            textBox3.Clear();
                            MostrarC(C.Ver());
                            copia3 = textBox3.Text;
                            label4.Text = "Valor tomado: ";
                            intentos++;
                            label5.Text = "Intentos: " + intentos;
                            contadorNodosC++;
                            cargada = true;
                            #endregion
                        }
                    }
                    else
                    {
                        if (A.Ver().Valor % 2 == 0)
                        {

                        }
                        else
                        {
                            #region Des B - Ap C
                            cargada = false;
                            tomador = B.Ver().Valor;
                            UltimoJugado = B.Ver();
                            B.Desapilar();
                            textBox2.Clear();
                            MostrarB(B.Ver());
                            copia2 = textBox2.Text;
                            label4.Text = "Valor tomado: " + tomador.ToString();
                            C.Apilar();
                            C.Ver().Valor = tomador;
                            tomador = 0;
                            textBox3.Clear();
                            MostrarC(C.Ver());
                            copia3 = textBox3.Text;
                            label4.Text = "Valor tomado: ";
                            intentos++;
                            label5.Text = "Intentos: " + intentos;
                            contadorNodosC++;
                            cargada = true;
                            #endregion
                        }
                    }
                }
            }

            else if (A.Ver() != null && B.Ver() == null && C.Ver() != null)
            {
                if (Tnumeros % 2 != 0)
                {
                    if (UltimoJugado.Valor == 1)
                    {
                        if (A.Ver().Valor % 2 == 0)
                        {
                            #region Des A - Ap B
                            cargada = false;
                            tomador = A.Ver().Valor;
                            UltimoJugado = A.Ver();
                            A.Desapilar();
                            textBox1.Clear();
                            MostrarA(A.Ver());
                            copia1 = textBox1.Text;
                            label4.Text = "Valor tomado: " + tomador.ToString();
                            B.Apilar();
                            B.Ver().Valor = tomador;
                            tomador = 0;
                            textBox2.Clear();
                            MostrarB(B.Ver());
                            copia2 = textBox2.Text;
                            label4.Text = "Valor tomado: ";
                            intentos++;
                            label5.Text = "Intentos: " + intentos;
                            cargada = true;
                            #endregion
                        }
                    }
                    else
                    {
                        if (A.Ver().Valor == 1)
                        {
                            if (C.Ver().Valor % 2 == 0)
                            {
                                #region Des A - Ap C
                                cargada = false;
                                tomador = A.Ver().Valor;
                                UltimoJugado = A.Ver();
                                A.Desapilar();
                                textBox1.Clear();
                                MostrarA(A.Ver());
                                copia1 = textBox1.Text;
                                label4.Text = "Valor tomado: " + tomador.ToString();
                                C.Apilar();
                                C.Ver().Valor = tomador;
                                tomador = 0;
                                textBox3.Clear();
                                MostrarC(C.Ver());
                                copia3 = textBox3.Text;
                                label4.Text = "Valor tomado: ";
                                intentos++;
                                label5.Text = "Intentos: " + intentos;
                                contadorNodosC++;
                                cargada = true;
                                #endregion
                            }
                            else
                            {

                            }
                        }
                        else
                        {
                            if (A.Ver().Valor % 2 == 0)
                            {

                            }
                            else
                            {

                            }
                        }
                    }
                }
                else
                {
                    if (UltimoJugado.Valor == 1)
                    {
                        if (A.Ver().Valor % 2 != 0)
                        {
                            #region Des A - Ap B
                            cargada = false;
                            tomador = A.Ver().Valor;
                            UltimoJugado = A.Ver();
                            A.Desapilar();
                            textBox1.Clear();
                            MostrarA(A.Ver());
                            copia1 = textBox1.Text;
                            label4.Text = "Valor tomado: " + tomador.ToString();
                            B.Apilar();
                            B.Ver().Valor = tomador;
                            tomador = 0;
                            textBox2.Clear();
                            MostrarB(B.Ver());
                            copia2 = textBox2.Text;
                            label4.Text = "Valor tomado: ";
                            intentos++;
                            label5.Text = "Intentos: " + intentos;
                            cargada = true;
                            #endregion
                        }
                    }
                    else
                    {
                        if (A.Ver().Valor == 1)
                        {
                            if (C.Ver().Valor % 2 == 0)
                            {
                                #region Des A - Ap C
                                cargada = false;
                                tomador = A.Ver().Valor;
                                UltimoJugado = A.Ver();
                                A.Desapilar();
                                textBox1.Clear();
                                MostrarA(A.Ver());
                                copia1 = textBox1.Text;
                                label4.Text = "Valor tomado: " + tomador.ToString();
                                C.Apilar();
                                C.Ver().Valor = tomador;
                                tomador = 0;
                                textBox3.Clear();
                                MostrarC(C.Ver());
                                copia3 = textBox3.Text;
                                label4.Text = "Valor tomado: ";
                                intentos++;
                                label5.Text = "Intentos: " + intentos;
                                contadorNodosC++;
                                cargada = true;
                                #endregion
                            }
                            else
                            {
                                #region Des A - Ap B
                                cargada = false;
                                tomador = A.Ver().Valor;
                                UltimoJugado = A.Ver();
                                A.Desapilar();
                                textBox1.Clear();
                                MostrarA(A.Ver());
                                copia1 = textBox1.Text;
                                label4.Text = "Valor tomado: " + tomador.ToString();
                                B.Apilar();
                                B.Ver().Valor = tomador;
                                tomador = 0;
                                textBox2.Clear();
                                MostrarB(B.Ver());
                                copia2 = textBox2.Text;
                                label4.Text = "Valor tomado: ";
                                intentos++;
                                label5.Text = "Intentos: " + intentos;
                                cargada = true;
                                #endregion
                            }
                        }
                        else
                        {
                            if (A.Ver().Valor % 2 == 0)
                            {

                            }
                            else
                            {

                            }
                        }
                    }
                }
            }

            else if (A.Ver() == null && B.Ver() != null && C.Ver() != null)
            {
                if (UltimoJugado.Valor == 1)
                {
                    if (B.Ver().Valor == 1)
                    {
                        #region Des C - Ap A
                        cargada = false;
                        tomador = C.Ver().Valor;
                        UltimoJugado = C.Ver();
                        C.Desapilar();
                        textBox3.Clear();
                        MostrarC(C.Ver());
                        copia3 = textBox3.Text;
                        label4.Text = "Valor tomado: " + tomador.ToString();
                        contadorNodosC--;
                        A.Apilar();
                        A.Ver().Valor = tomador;
                        tomador = 0;
                        textBox1.Clear();
                        MostrarA(A.Ver());
                        copia1 = textBox1.Text;
                        label4.Text = "Valor tomado: ";
                        intentos++;
                        label5.Text = "Intentos: " + intentos;
                        cargada = true;
                        #endregion
                    }
                    else
                    {
                        #region Des B - Ap A
                        cargada = false;
                        tomador = B.Ver().Valor;
                        UltimoJugado = B.Ver();
                        B.Desapilar();
                        textBox2.Clear();
                        MostrarB(B.Ver());
                        copia2 = textBox2.Text;
                        label4.Text = "Valor tomado: " + tomador.ToString();
                        A.Apilar();
                        A.Ver().Valor = tomador;
                        tomador = 0;
                        textBox1.Clear();
                        MostrarA(A.Ver());
                        copia1 = textBox1.Text;
                        label4.Text = "Valor tomado: ";
                        intentos++;
                        label5.Text = "Intentos: " + intentos;
                        cargada = true;
                        #endregion
                    }
                }
                else
                {
                    if (B.Ver().Valor == 1)
                    {
                        if (C.Ver().Valor % 2 == 0)
                        {
                            #region Des B - Ap C
                            cargada = false;
                            tomador = B.Ver().Valor;
                            UltimoJugado = B.Ver();
                            B.Desapilar();
                            textBox2.Clear();
                            MostrarB(B.Ver());
                            copia2 = textBox2.Text;
                            label4.Text = "Valor tomado: " + tomador.ToString();
                            C.Apilar();
                            C.Ver().Valor = tomador;
                            tomador = 0;
                            textBox3.Clear();
                            MostrarC(C.Ver());
                            copia3 = textBox3.Text;
                            label4.Text = "Valor tomado: ";
                            intentos++;
                            label5.Text = "Intentos: " + intentos;
                            contadorNodosC++;
                            cargada = true;
                            #endregion
                        }
                        else
                        {
                            #region Des B - Ap A
                            cargada = false;
                            tomador = B.Ver().Valor;
                            UltimoJugado = B.Ver();
                            B.Desapilar();
                            textBox2.Clear();
                            MostrarB(B.Ver());
                            copia2 = textBox2.Text;
                            label4.Text = "Valor tomado: " + tomador.ToString();
                            A.Apilar();
                            A.Ver().Valor = tomador;
                            tomador = 0;
                            textBox1.Clear();
                            MostrarA(A.Ver());
                            copia1 = textBox1.Text;
                            label4.Text = "Valor tomado: ";
                            intentos++;
                            label5.Text = "Intentos: " + intentos;
                            cargada = true;
                            #endregion
                        }
                    }
                    else
                    {
                        if (B.Ver().Valor % 2 == 0)
                        {
                            #region Des C - Ap A
                            cargada = false;
                            tomador = C.Ver().Valor;
                            UltimoJugado = C.Ver();
                            C.Desapilar();
                            textBox3.Clear();
                            MostrarC(C.Ver());
                            copia3 = textBox3.Text;
                            label4.Text = "Valor tomado: " + tomador.ToString();
                            contadorNodosC--;
                            A.Apilar();
                            A.Ver().Valor = tomador;
                            tomador = 0;
                            textBox1.Clear();
                            MostrarA(A.Ver());
                            copia1 = textBox1.Text;
                            label4.Text = "Valor tomado: ";
                            intentos++;
                            label5.Text = "Intentos: " + intentos;
                            cargada = true;
                            #endregion
                        }
                        else
                        {
                            #region Des C - Ap A
                            cargada = false;
                            tomador = C.Ver().Valor;
                            UltimoJugado = C.Ver();
                            C.Desapilar();
                            textBox3.Clear();
                            MostrarC(C.Ver());
                            copia3 = textBox3.Text;
                            label4.Text = "Valor tomado: " + tomador.ToString();
                            contadorNodosC--;
                            A.Apilar();
                            A.Ver().Valor = tomador;
                            tomador = 0;
                            textBox1.Clear();
                            MostrarA(A.Ver());
                            copia1 = textBox1.Text;
                            label4.Text = "Valor tomado: ";
                            intentos++;
                            label5.Text = "Intentos: " + intentos;
                            cargada = true;
                            #endregion
                        }
                    }
                }
            }

            else if (A.Ver() == null && B.Ver() == null && C.Ver() != null)
            {
                timer1.Enabled = false;
                MessageBox.Show("GANASTE!!!");
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                button2.Text = "Activar \"Juego automático\"";
                button2.Enabled = false;
                label6.Enabled = false;
                hScrollBar1.Enabled = false;
            }
        }

        private void hScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = hScrollBar1.Value;
        }
        #endregion

        #region Funciones
        private void DesapilarTodo(Nodo pnodo,Pila ppila)
        {
            if(pnodo!=null)
            {
                ppila.Desapilar();
                DesapilarTodo(pnodo.Anterior, ppila);
            }
        }

        private void repuestos ()
        {
            #region Des A - Ap B
            cargada = false;
            tomador = A.Ver().Valor;
            UltimoJugado = A.Ver();
            A.Desapilar();
            textBox1.Clear();
            MostrarA(A.Ver());
            copia1 = textBox1.Text;
            label4.Text = "Valor tomado: " + tomador.ToString();
            B.Apilar();
            B.Ver().Valor = tomador;
            tomador = 0;
            textBox2.Clear();
            MostrarB(B.Ver());
            copia2 = textBox2.Text;
            label4.Text = "Valor tomado: ";
            intentos++;
            label5.Text = "Intentos: " + intentos;
            cargada = true;
            #endregion

            #region Des A - Ap C
            cargada = false;
            tomador = A.Ver().Valor;
            UltimoJugado = A.Ver();
            A.Desapilar();
            textBox1.Clear();
            MostrarA(A.Ver());
            copia1 = textBox1.Text;
            label4.Text = "Valor tomado: " + tomador.ToString();
            C.Apilar();
            C.Ver().Valor = tomador;
            tomador = 0;
            textBox3.Clear();
            MostrarC(C.Ver());
            copia3 = textBox3.Text;
            label4.Text = "Valor tomado: ";
            intentos++;
            label5.Text = "Intentos: " + intentos;
            contadorNodosC++;
            cargada = true;
            #endregion

            #region Des B - Ap A
            cargada = false;
            tomador = B.Ver().Valor;
            UltimoJugado = B.Ver();
            B.Desapilar();
            textBox2.Clear();
            MostrarB(B.Ver());
            copia2 = textBox2.Text;
            label4.Text = "Valor tomado: " + tomador.ToString();
            A.Apilar();
            A.Ver().Valor = tomador;
            tomador = 0;
            textBox1.Clear();
            MostrarA(A.Ver());
            copia1 = textBox1.Text;
            label4.Text = "Valor tomado: ";
            intentos++;
            label5.Text = "Intentos: " + intentos;
            cargada = true;
            #endregion

            #region Des B - Ap C
            cargada = false;
            tomador = B.Ver().Valor;
            UltimoJugado = B.Ver();
            B.Desapilar();
            textBox2.Clear();
            MostrarB(B.Ver());
            copia2 = textBox2.Text;
            label4.Text = "Valor tomado: " + tomador.ToString();
            C.Apilar();
            C.Ver().Valor = tomador;
            tomador = 0;
            textBox3.Clear();
            MostrarC(C.Ver());
            copia3 = textBox3.Text;
            label4.Text = "Valor tomado: ";
            intentos++;
            label5.Text = "Intentos: " + intentos;
            contadorNodosC++;
            cargada = true;
            #endregion

            #region Des C - Ap B
            cargada = false;
            tomador = C.Ver().Valor;
            UltimoJugado = C.Ver();
            C.Desapilar();
            textBox3.Clear();
            MostrarC(C.Ver());
            copia3 = textBox3.Text;
            label4.Text = "Valor tomado: " + tomador.ToString();
            contadorNodosC--;
            B.Apilar();
            B.Ver().Valor = tomador;
            tomador = 0;
            textBox2.Clear();
            MostrarB(B.Ver());
            copia2 = textBox2.Text;
            label4.Text = "Valor tomado: ";
            intentos++;
            label5.Text = "Intentos: " + intentos;
            cargada = true;
            #endregion

            #region Des C - Ap A
            cargada = false;
            tomador = C.Ver().Valor;
            UltimoJugado = C.Ver();
            C.Desapilar();
            textBox3.Clear();
            MostrarC(C.Ver());
            copia3 = textBox3.Text;
            label4.Text = "Valor tomado: " + tomador.ToString();
            contadorNodosC--;
            A.Apilar();
            A.Ver().Valor = tomador;
            tomador = 0;
            textBox1.Clear();
            MostrarA(A.Ver());
            copia1 = textBox1.Text;
            label4.Text = "Valor tomado: ";
            intentos++;
            label5.Text = "Intentos: " + intentos;
            cargada = true;
            #endregion
        }

        private void MostrarA (Nodo pnodo)
        {
            if(pnodo!=null)
            {
                textBox1.Text =  textBox1.Text + " " + "\n" + pnodo.Valor.ToString();
                MostrarA(pnodo.Anterior);
            }
        }

        private void MostrarB (Nodo pnodo)
        {
            if (pnodo != null)
            {
                textBox2.Text = textBox2.Text + " "+"\n" + pnodo.Valor.ToString();
                MostrarB(pnodo.Anterior);
            }
        }

        private void MostrarC (Nodo pnodo)
        {
            if (pnodo != null)
            {
                textBox3.Text = textBox3.Text + " " + "\n" + pnodo.Valor.ToString();
                MostrarC(pnodo.Anterior);
            }
        }

        private void Fichas(int cantidad)
        {
            cargada = false;
            DesapilarTodo(A.Ver(), A);
            DesapilarTodo(B.Ver(), B);
            DesapilarTodo(C.Ver(), C);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            tomador = 0;
            for (int cont1 = cantidad; cont1 >= 1; cont1--)
            {
                A.Apilar();
                A.Ver().Valor = cont1;
            }
            MostrarA(A.Ver());
            copia1 = textBox1.Text;
            copia2 = textBox2.Text;
            copia3 = textBox3.Text;
            label4.Text = "Valor tomado: ";
            intentos = 0;
            label5.Text = "Intentos: " + intentos;
            contadorNodosC = 0;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            if (timer1.Enabled == true)
            {
                timer1.Enabled = false;
                button2.Text = "Activar \"Juego automático\"";
                label6.Enabled = false;
                hScrollBar1.Enabled = false;
            }
            button2.Enabled = true;
            cargada = true;
        }
        #endregion
    }
}
