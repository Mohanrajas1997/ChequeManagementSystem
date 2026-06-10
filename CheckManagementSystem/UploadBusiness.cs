using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CheckManagementSystem;
using System.Configuration;
using System.Windows.Forms;

namespace CheckManagementSystem
{
   public class UploadBusiness
    {
       string apiurl = ConfigurationManager.AppSettings["APIServerURL"].ToString();
       public DataTable  GetSingleUploadDetails(int UploadGid)
       {
           DataTable dsUploadDtls = new DataTable();
           try
           {
               Dictionary<string, Object> values = new Dictionary<string, object>();
               DataConnection con = new DataConnection();
               values.Add("In_uploadgid", UploadGid);
               dsUploadDtls = con.RunProc("sp_get_uploadcode", values);
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
           return dsUploadDtls;
       }
       public DataTable GetSinlgeScanImage(int UploadGid,int ChqGid)
       {
           DataTable dtScanDtls = new DataTable();
           try
           {
               Dictionary<string, Object> values = new Dictionary<string, object>();
               DataConnection con = new DataConnection();
               values.Add("In_UploadGid", UploadGid);
               values.Add("In_chqgid", ChqGid);
               dtScanDtls = con.RunProc("sp_get_scanimage_upload", values);
           }
           catch(Exception ex){
               MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
           return dtScanDtls;
       }
    }
}
