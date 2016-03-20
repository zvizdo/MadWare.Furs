using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadWare.Furs.Models.Invoice
{
    /// <summary>
    /// Vpišejo se podatki o računu, ki je izdan z uporabo elektronske naprave. / Data are entered about the invoice, which is issued with usage of the electronic device.
    /// </summary>
    public class Invoice : BaseInvoice
    {
        public enum NumberingStructureEnum { C, B }

        /// <summary>
        /// Vpiše se oznaka načina dodeljevanja številk računom / The mark is entered for the method of assigning numbers to invoices:
        /// C – centralno na nivoju poslovnega prostora / centrally at the level of business premises
        /// B – po posamezni elektronski napravi(blagajna) / per individual electronic device(cash register)
        /// Oznaka pojasnjuje na kakšen način se računom dodeljujejo številke. / The mark explains the method for assigning numbers to invoices.
        /// Številke računov se lahko dodeljujejo centralno na nivoju poslovnega prostora ali posamično na elektronski napravi za izdajanje računov. / Invoice numbers may be assigned centrally at the level of business premises or individually on the electronic device for issuing invoices.
        /// </summary>
        public NumberingStructureEnum NumberingStructure { get; set; }

        /// <summary>
        /// Vpiše se številka izdanega računa. / The number of the issued invoice is entered.
        /// Vpiše se tudi številka dokumenta, ki spreminja prvotni račun(dobropis, storno,…) v primeru izvajanja postopka potrjevanja naknadne spremembe podatkov na računu, ki spreminja prvoten račun in se nanj nedvoumno nanaša. / The number of the document is also entered, which changes the original invoice (credit, reversing, etc.) in cases of performing the procedure for verification of subsequent changes of data on the invoice, which changes the original invoice and refers to it with reasonable certainty.
        /// Številka računa je sestavljena iz treh delov / The invoice number includes three parts:
        /// - Oznaka poslovnega prostora / Mark of business premises
        /// - Oznaka elektronske naprave za izdajanje računov / Mark of the electronic device for issuing invoices
        /// - Zaporedna številka računa / Sequence number of the invoice
        /// Številka računa se na računu navede v naslednji obliki / The invoice number is stated on the invoice in the following form:
        /// oznaka poslovnega prostora-oznaka elektronske naprave-zaporedna številka računa / mark of business premises-mark of the electronic device-sequence invoice number
        /// Primer / Example: TRGOVINA1-BLAG2-1234
        /// Podatki se vpisujejo ločeno. / Data are entered separately.
        /// </summary>
        public InvoiceIdentifier InvoiceIdentifier { get; set; }

        /// <summary>
        /// Vpiše še davčna številka fizične osebe (operaterja), ki izda račun z uporabo elektronske naprave za izdajanje računov.
        /// V primeru izdaje računa preko samopostrežnih elektronskih naprav oziroma ko se račun izda brez prisotnosti fizične osebe, se vpiše davčna številka zavezanca. / The tax number is entered of the individual(operator), who issues the invoice with the usage of the electronic device for issuing invoices.In cases of issuing invoices via self-service electronic devices or when invoices are issued without the presence of individuals, the tax number of the person liable is entered.
        /// Če oseba nima slovenske davčne številke, se podatek ne vpisuje. / The data is not entered if the person has no Slovene tax number.
        /// </summary>
        public string OperatorTaxNumber { get; set; }

        /// <summary>
        /// Vpiše se true, če fizična oseba (operater), ki izda račun z uporabo elektronske naprave, nima slovenske davčne številke, drugače false (1 - true, 0 – false). / You enter »true« if the individual (operator), who issues the invoice with the usage of the electronic device, has no Slovene tax number, otherwise »false« (1 – true, 0 – false).
        /// </summary>
        public bool? ForeignOperator { get; set; }

        /// <summary>
        /// Vpiše se zaščitna oznaka izdajatelja računa. / The protective mark of the invoice issuer is entered.
        /// Zaščitna oznaka je sestavljena iz 32 znakov v heksadecimalnem formatu. / The protective mark includes 32 characters in the hexadecimal notation.
        /// Primer / Example: 8202f0f963e37a2258b034cf8ae7bbc1
        /// </summary>
        public string ProtectedID { get; set; }

        /// <summary>
        /// Naknadno posredovani račun je račun, ki je bil izdan brez enkratne identifikacijske oznake računa – EOR (npr. zaradi prekinitve elektronske povezave z davčnim organom).
        /// Vpiše se true, če je račun naknadno posredovan davčnemu organu, drugače false (1 – true, 0 – false). / Subsequently submitted invoices are invoices, which have been issued without the unique identification invoice mark – EOR(e.g.due to disconnections of electronic connections with the tax authority). If the invoice is subsequently submitted to the tax authority, »true« is entered, otherwise »false« (1 – true, 0 – false).
        /// </summary>
        public bool? SubsequentSubmit { get; set; }

        public bool ShouldSerializeSubsequentSubmit()
        {
            return this.SubsequentSubmit.HasValue;
        }

        public bool ShouldSerializeForeignOperator()
        {
            return this.ForeignOperator.HasValue;
        }

        public bool ShouldSerializeOperatorTaxNumber()
        {
            return !string.IsNullOrEmpty(this.OperatorTaxNumber);
        }

    }
}
