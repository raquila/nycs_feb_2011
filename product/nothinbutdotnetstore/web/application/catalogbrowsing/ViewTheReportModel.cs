using System;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.utility;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewTheReportModel<T>:ApplicationBehaviour
    {
        ResponseEngine response_engine;
        Catalog<T> store_catalog;

        public ViewTheReportModel(): this(Stub.with<StubResponseEngine>(),Stub.with<StubStoreCatalog>())
        {
        }

        private ViewTheReportModel(ResponseEngine response_engine, Catalog<T> store_catalog)
        {
            this.response_engine = response_engine;
            this.store_catalog = store_catalog;
        }

        public void run(Request request)
        {
            response_engine.display(store_catalog.query_by(request.map<T>()));
        }
    }
}