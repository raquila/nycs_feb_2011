 using System.Collections.Generic;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.specs.utility;
 using nothinbutdotnetstore.tasks;
 using nothinbutdotnetstore.web.application.catalogbrowsing;
 using nothinbutdotnetstore.web.application.model;
 using nothinbutdotnetstore.web.core;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{   
    public class ViewTheProductsInADepartementSpecs
    {
        public abstract class concern : Observes<ApplicationBehaviour,
                                            ViewTheProductsInADepartment>
        {
        
        }

        [Subject(typeof(ViewTheProductsInADepartment))]
        public class when_run : concern
        {
            private static ResponseEngine response_engine;
            private static IEnumerable<Product> products;
            private static Request request;
            private static Department department;
            private static StoreCatalog store_catalog;

            private Establish c = () =>
                                      {
                                          response_engine = the_dependency<ResponseEngine>();
                                          store_catalog = the_dependency<StoreCatalog>();
                                          request = an<Request>();
                                          products = ObjectFactory.create_a_set_of(100, () => new Product());
                                          department = an<Department>();

                                          request.Stub(x => x.get_a<IEnumerable<Product>>()).Return(products);

                                          store_catalog.Stub(x => x.get_products_for(department)).Return(products);
                                      };

            private Because b = () => sut.run(request);
            private It should_display_the_products = () => response_engine.received(x => x.display(products));
        }
    }
}
