using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBManagement
{
    internal interface SqlMethods 
    {
        public void SearchTransportReq();
        public void SearchTrf();
        public void SearchTrfInfo();
        public void ReqList();
        public void SearchTransfer();
        public void SearchReq();
        public void SearchDeleteTransfer();
        public void CstActHistSearch();
        public void CstEventHistSearch();
        public void SearchLnsPkgLot();
        public void SearchLnsPkgEqp();
        public void SearchCstInfo();
        public void SearchCstInfo2();
        public void SearchEqpState();
        public void SearchEqpGroup();
        public void SearchPortState();
        public void SearchPortStateHist();
        public void SearchPortEioHist();
        public void SearchStkComCode();
        public void SearchStkInventory();
        public void SearchAgingUIHist();
        public void SearchStockerCurrState();
        public void SearchWaitingWips();
        public void RollCurrentSituation();
    }
}
