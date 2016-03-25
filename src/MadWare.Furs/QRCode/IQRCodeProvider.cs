using MadWare.Furs.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadWare.Furs.QRCode
{
    public interface IQRCodeProvider
    {

        string GenerateQRCode(QRCodeModel model);

    }
}
