using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MasterDataService.AppCode;
using System.Data;

namespace MasterDataService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class Service1 : IService1
    {
        /// <summary>
        /// hàm insert danh mục bệnh nhân
        /// </summary>
        /// <param name="DM_BenhNhan"></param>
        /// <returns>-1, master_id</returns>
        public string AddNew(clsDM_BenhNhan DM_BenhNhan)
        {
            return DM_BenhNhan.AddNew();

        }
        public string Update(clsDM_BenhNhan DM_BenhNhan)
        {
            return DM_BenhNhan.Update();

        }

        public DataSet GetDsBenhNhanTrung(clsDM_BenhNhan bn) {
            return bn.GetDsBenhNhanTrung();
        }
      
    }
}
