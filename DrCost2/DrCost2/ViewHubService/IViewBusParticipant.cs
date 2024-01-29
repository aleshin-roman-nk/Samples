using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrCost2.dtoservices;

namespace DrCost2.ViewHubService
{
    public interface IViewBusParticipant
    {
        void PutMessage(ViewBusMessage msg);
        //void hide();
        //void rise();
        //void oper();
    }
}
