using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckManagementSystem
{
    public class SaveScanner
    {
        public List<ScannerEntities> SaveScannerData { get; set; }
    }
    public class ScannerEntities
    {
        public int scan_id { get; set; }
        public int serial_no { get; set; }
        public string check_no { get; set; }
        public string sort_code { get; set; }
        public string update_micr { get; set; }
        public string base_code { get; set; }
        public string tran_code { get; set; }
        public string images { get; set; }
        public string batch_no { get; set; }
        public int batch_id { get; set; }
        public string cheq_no { get; set; }
        public string front_image { get; set; }
        public string back_image { get; set; }
        public string greyfront_image { get; set; }
        public string greyback_image { get; set; }
        public string front_uv_image { get; set; }
        public string back_uv_image { get; set; }
        public string created_by { get; set; }
        public string status { get; set; }
        public string scan_type { get; set; }
    }

    public class uploadgrid
    {
        public string batch_no { get; set; }
        public string cheque_count { get; set; }
        public string batch_amount { get; set; }
        public string depslip_no { get; set; }
        public string cus_code { get; set; }
        //public string upload_batch_no { get; set; }
        //public int upload_link_no { get; set; }
    }

    public class CheckerEntities
    {
        public string in_Scanning_ID { get; set; }
        public string in_Batch_No { get; set; }
        public string in_Cheq_no { get; set; }
        public string in_Sort_Code { get; set; }
        public string in_Base_Code { get; set; }
        public string in_Tran_Code { get; set; }
        public DateTime in_Che_Date { get; set; }
        public int in_Amount { get; set; }
        public string in_Account_No { get; set; }
        public string in_Drawee_Name { get; set; }
        public string in_Status { get; set; }
        public string in_user { get; set; }
    }

    public class UploadImageEntities
    {
        public string in_front_image { get; set; }
        public string in_back_image { get; set; }
        public string in_front_uv_image { get; set; }
        public string in_back_uv_image { get; set; }
        public string in_batch_no { get; set; }

    }
    public class RejectionEntites
    {
        public string in_cheque_no { get; set; }
        public string in_cheque_amount { get; set; }
    }
    public class AdjustScanCountEntities
    {
        public string batch_no { get; set; }
        public int cheque_count { get; set; }
    }
    public class BatchUploadEntities
    {
        public string batch_no { get; set; }
        public string upload_id { get; set; }
        public string upload_code { get; set; }
        public string batch_link_no { get; set; }
        public string upload_type { get; set; }
        public string upload_by { get; set; }
        public string generate_type { get; set; }
    }

    public class BatchAMTUpdateEntities
    {
        public string batch_no { get; set; }
        public string Amount { get; set; }
    }
    public class CTSScanEntities
    {
        public string[] batchlist { get; set; }
        public string out_msg { get; set; }
        public string out_result { get; set; }
        public string cts_link { get; set; }
    }
    public class xmlfileread
    {
        public string FileName { get; set; }
        public string ItemSeqNo { get; set; }
        public string Batchno { get; set; }
        public string BatchnoSeqNo { get; set; }
        public string SeqNo { get; set; }
        public string Filepath { get; set; }
        public string FGFileName { get; set; }
        public string FBFileName { get; set; }
        public string FUFileName { get; set; }
        public string RBFileName { get; set; }
        public string Deptslipno { get; set; }
        public string ChequeCount { get; set; }

    }
    public class NewUploaEntites
    {
        public string batch_no { get; set; }
        public string upload_linkno { get; set; }
        public string generate_type { get; set; }
        public string upload_code { get; set; }
        public string location_name { get; set; }
        public int from_index { get; set; }
        public int to_index { get; set; }


    }

    public class RhevEntities
    {
        public string from_date { get; set; }
        public string to_date { get; set; }
    }

    public class RejectEntities
    {
        public string in_Batch_no { get; set; }
        public string in_Scanning_ID { get; set; }
        public string in_Cheq_no { get; set; }
        public string in_Sort_Code { get; set; }
        public string in_Base_Code { get; set; }
        public string in_Tran_Code { get; set; }
        public string in_Che_Date { get; set; }
        public string in_Amount { get; set; }
        public string in_Account_No { get; set; }
        public string in_Drawee_Name { get; set; }
        public string in_Reason { get; set; }
        public string in_Status { get; set; }
        public string in_user { get; set; }
        public string wherecondition { get; set; }
    }
    public class UploadEntitiesNew
    {
        public string batch_no { get; set; }
        public string batch_cheque_count { get; set; }
        public string batch_amount { get; set; }
        public string batch_dep_slip_no { get; set; }
        public string customer_code { get; set; }
        public string cheq_no { get; set; }
        public string sort_code { get; set; }
        public string base_code { get; set; }
        public string tran_code { get; set; }
        public string front_image { get; set; }
        public string back_image { get; set; }
        public string front_uv_image { get; set; }
        public string grey_back { get; set; }
        public string grey_front { get; set; }
        public string Amount { get; set; }
        public string Drawee_Name { get; set; }
        public string Che_Date { get; set; }
        public string Account_No { get; set; }
        public string LOCATION_CODE { get; set; }
        public string BANK_CODE { get; set; }
        public string batch_code { get; set; }
        public string seq_id { get; set; }
        public string FrontGrayImageName { get; set; }
        public string FrontBlackImageName { get; set; }
        public string ReverseBlackImageName { get; set; }
        public string FrontUVImageName { get; set; }
        public string SingleXMLImage { get; set; }
        public string Finacle { get; set; }
    }
    public class StatusWiseChequeList
    {
        public string in_Batch_No { get; set; }
        public string in_Status { get; set; }
    }
    public class UpdateMicrEntites
    {
        public string batch_no { get; set; }
        public string ex_micr { get; set; }
    }
}
