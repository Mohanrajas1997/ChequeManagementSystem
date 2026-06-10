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
    public class BatchEntryBusiness
    {
        public DataTable GetCustomerDetails()
        {
            DataTable ds = new DataTable();
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                ds = con.RunProc("sp_get_customers", values);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ds;
        }

        public string[] SaveBatchEntry(BatchEntryEntities BatchValues)
        {
            string[] result = { };
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("In_batch_gid", BatchValues.BatchGid);
                values.Add("In_batch_no", BatchValues.BatchNo);
                values.Add("In_chq_type", BatchValues.ChqType);
                values.Add("In_cts_acc_type", BatchValues.CtsAccType);
                values.Add("In_cts_acc_no", BatchValues.CtsSingleAccNo);
                values.Add("In_cts_acc_name", BatchValues.CtsSingleAccHolderName);
                values.Add("In_dep_slip_no", BatchValues.DepositSlipNo);
                values.Add("In_customer_code", BatchValues.CustomerCode);
                values.Add("In_tot_chq_count", BatchValues.TotalChqCount);
                values.Add("In_tot_batch_amount", BatchValues.TotalBatchAmount);
                values.Add("In_inward_gid", BatchValues.InwardGid);
                values.Add("In_User", BatchValues.created_by);
                values.Add("In_action", BatchValues.action);
                values.Add("out_msg", "out");
                values.Add("out_result", "out");
                result = con.RunDmlProc("sp_ins_batchentry", values);
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        public string GetInwardQueueCode(int inward_gid)
        {
            string inward_queue_code="";
            DataTable dt = new DataTable();

            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("in_inward_gid", inward_gid);
                dt = con.RunProc("sp_get_inward", values);

                if (dt.Rows.Count > 0) inward_queue_code = dt.Rows[0]["inward_queue_code"].ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return inward_queue_code;
        }

        public string GetBatchQueueCode(int batch_gid)
        {
            string batch_queue_code = "";
            DataTable dt = new DataTable();

            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("in_batch_gid", batch_gid);
                dt = con.RunProc("sp_get_batch", values);

                if (dt.Rows.Count > 0) batch_queue_code = dt.Rows[0]["batch_queue_code"].ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return batch_queue_code;
        }

        public DataTable GetBatch(int batch_gid)
        {
            DataTable dt = new DataTable();

            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("in_batch_gid", batch_gid);
                dt = con.RunProc("sp_get_batch", values);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }

        public DataTable GetBatchEntry(int InwardGid)
        {
            DataTable dt = new DataTable();
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("In_Inward_gid", InwardGid);
                dt = con.RunProc("sp_get_single_batchdetails", values);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;

        }
    }
}
