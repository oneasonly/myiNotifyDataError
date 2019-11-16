using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WPFValidationINotifyDataErrorInfo
{
    [XmlRoot]
    public class PayRecord
    {

        [XmlAttribute()]
        public string Code { get; set; }
        [XmlAttribute()]
        public string Name { get; set; }
        [XmlAttribute()]
        public string StornoMode { get; set; }
        [XmlAttribute()]
        public string Commission { get; set; }
        [XmlAttribute()]
        public string Summa { get; set; }
        [XmlAttribute()]
        public short View { get; set; } = 1;
        [XmlAttribute()]
        public string Fine { get; set; }
        [XmlAttribute()]
        public string PayCommission { get; set; }
        [XmlAttribute()]
        public string SessionId { get; set; }
        [XmlAttribute()]
        public string Edit { get; set; }
        [XmlAttribute()]
        public string GetPayListType { get; set; }
        [XmlAttribute()]
        public string RecordID { get; set; }
        [XmlAttribute()]
        public string PaymentID { get; set; }
        [XmlAttribute()]
        public string PC_ID { get; set; }
        [XmlAttribute()]
        public string PayAll { get; set; }
        [XmlAttribute()]
        public string KioskReceipt { get; set; }
        [XmlAttribute()]
        public string Date { get; set; }
        [XmlAttribute()]
        public string ClaimID { get; set; }
        [XmlAttribute()]
        public string DIType { get; set; }
        [XmlAttribute()]
        public string Currency { get; set; }
        [XmlAttribute()]
        public string CodeOut { get; set; }
        [XmlAttribute()]
        public string Label { get; set; }
        [XmlAttribute()]
        public string CancelReason { get; set; }
        [XmlAttribute()]
        public string ConfirmCode { get; set; }
    }
}
