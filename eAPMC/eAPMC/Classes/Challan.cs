using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAPMC.Classes
{
    public class Challan
    {
        public Int64 challanID { get; set; }

        public string ChallanNo { get; set; }

        public string WeighingReceiptNo { get; set; }

        public DateTime ChallanDate { get; set; }

        public DateTime ChallanTime { get; set; }

        public Int64 SessionID { get; set; }

        public bool IsDeleted { get; set; }

    }

    public class ChallanDocument
    {
        public Int64 DocumentID { get; set; }

        public Int64 ChallanID { get; set; }

        public int DocumentTypeCode { get; set; }

        public string DocumentTypeDesc { get; set; }

        public byte[] iDocument { get; set; }

    }

    public class ChallanDriver
    {
        public Int64 ChallanDriverID { get; set; }

        public Int64 ChallanID { get; set; }

        public Int64 PersonID { get; set; }
    }

    public class ChallanFarmer
    {
        public Int64 ChallanFarmerID { get; set; }

        public Int64 ChallanID { get; set; }

        public Int64 PersonID { get; set; }

    }

    public class ChallanItem
    {
        public Int64 ChallanItemID { get; set; }

        public Int64 ChallanID { get; set; }

        public int ItemTypeCode { get; set; }

        public string OtemTypeDesc { get; set; }

        public decimal QunatityInKg { get; set; }

        public decimal Rate { get; set; }

    }

    public class ChallanVehicle
    {
        public Int64 ChallanVehicleID { get; set; }

        public Int64 ChallanID { get; set; }

        public string VehicleRegNo { get; set; }

        public int VechileTypeCode { get; set; }

        public string VechileTypeDescr { get; set; }

        public decimal LoaddedWeight { get; set; }

        public decimal EmptyWeight { get; set; }
    }
}
