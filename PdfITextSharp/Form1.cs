using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PdfITextSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ListFieldNames();
            //FillForm();
            PreencherProposta();
        }

        //Lista o nome dos campos do formulario pdf
        private void ListFieldNames()
        {
            string pdfTemplate = @"C:\Users\ingrid.teixeira\Downloads\SamplePDFForm.pdf";

            this.Text += " - " + pdfTemplate;

            PdfReader pdfReader = new PdfReader(pdfTemplate);

            StringBuilder sb = new StringBuilder();
            foreach (var de in pdfReader.AcroFields.Fields)
            {
                sb.Append(de.Key.ToString() + Environment.NewLine);
            }

            textBox1.Text = sb.ToString();
            textBox1.SelectionStart = 0;
        }

        private void FillForm()
        {
            string caminhoTemplate = @"D:\.trash\PdfITextSharp\SamplePDFForm.pdf";
            string caminhoNovoArquivo = @"D:\.trash\PdfITextSharp\SamplePDFForm-NEW.pdf";

            using (var pdfTemplate = new PdfReader(caminhoTemplate))
            {
                // FormFlattening = desabilita a edição
                using (var pdfNovoArquivo = new PdfStamper(pdfTemplate, new FileStream(caminhoNovoArquivo, FileMode.Create)) { FormFlattening = true })
                {
                    var campos = pdfNovoArquivo.AcroFields;

                    //campos
                    campos.SetField("First Name", "Ingrid");
                    campos.SetField("Last Name", "Pires");

                    // checkbox
                    campos.SetField("Awesome Checkbox", "Yes");

                    string sTmp = "Fill Completed for " + campos.GetField("First Name");
                    MessageBox.Show(sTmp, "Finished");
                }
            }
        }

        private void PreencherProposta()
        {
            string caminhoTemplate = @"D:\.trash\PdfITextSharp\Proposta-Ameplan-26-11-19-form.pdf";
            string caminhoNovoArquivo = @"D:\.trash\PdfITextSharp\Proposta-Ameplan-26-11-19-form-NEW.pdf";

            using (var pdfTemplate = new PdfReader(caminhoTemplate))
            {
                using (var pdfNovoArquivo = new PdfStamper(pdfTemplate, new FileStream(caminhoNovoArquivo, FileMode.Create)) { FormFlattening = true })
                {
                    var campos = pdfNovoArquivo.AcroFields;
                    
                    campos.SetField("NumProposta", "1234535646");
                    //campos.SetField("Data de Nascimento", "04");
                    //campos.SetField("undefined", "07");
                    //campos.SetField("undefined_2", "1999");
                    //campos.SetField("Nome Completo da Mãe_2", "Lucia Teixeira");
                    //campos.SetField("Nome Completo do Pai_2", "Sidnei Pires");
                    //campos.SetField("Estado Civil_2", "Solt.");
                    //campos.SetField("Naturalidade", "URSS");
                    //campos.SetField("RG", "1656459285");
                    //campos.SetField("Orgão Emissor", "SS");
                    //campos.SetField("CPF_2", "165656256465");
                    //campos.SetField("Endereço Residencial", "Rua das Lágrimas");
                    //campos.SetField("N", "888");
                    //campos.SetField("Complemento", "Casa");
                    //campos.SetField("Bairro", "Vila Dolosa");
                    //campos.SetField("Cidade", "São Paulo");
                    //campos.SetField("CEP", "14959-5");
                    //campos.SetField("Fone Celular", "8956785");
                    //campos.SetField("Email", "ingrid@email.com");
                    //campos.SetField("Pro", "programer");
                    //campos.SetField("N do Cartão Nacional de Saúde_3", "5465325749555");
                    //campos.SetField("Data de Admissão", "12");
                    //campos.SetField("undefined_3", "02");
                    //campos.SetField("undefined_4", "2020");
                    //campos.SetField("Número PISPASEP", "15364847265");

                    //campos.SetField("Fem", "X");

                    string sTmp = "Fill Completed for " + campos.GetField("Nome Completo");
                    MessageBox.Show(sTmp, "Finished");
                }
            }
        }
    }
}
