 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.application.catalogbrowsing;
 using nothinbutdotnetstore.web.application.model;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{   
    public class UrlFormatterSpecs
    {
        public abstract class concern : Observes<UrlFormatter<ViewTheDepartmentsInADepartment>>
        {
        
        }

         [Subject(typeof (UrlFormatter<ViewTheDepartmentsInADepartment>))]
        public class when_adding_a_department : concern
        {
            private It should_return_a_string = () => result.ShouldContain(typeof(Department).Name);

            private Establish c = () =>
                                      {
                                          department = an<Department>();

                                      };

            private Because b = () =>
                                result = sut.include_in_payload(department).format();

            private static string result;
            private static Department department;
        }

        [Subject(typeof (UrlFormatter<ViewTheDepartmentsInADepartment>))]
        public class when_adding_a_department_to_a_payload : concern
        {
            private It first_observation = () => { };

            private Establish c = () =>
                                      {
                                          department = an<Department>();

                                      };

            private Because b
                = () => sut.include_in_payload(department).the_detail(x => x.has_products);

            private static Department department;



        }

    }
}
