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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string AddNew(clsDM_BenhNhan DM_BenhNhan);

        [OperationContract]
         DataSet GetDsBenhNhanTrung(clsDM_BenhNhan bn);
        [OperationContract]
         string Update(clsDM_BenhNhan DM_BenhNhan);
        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    
}
