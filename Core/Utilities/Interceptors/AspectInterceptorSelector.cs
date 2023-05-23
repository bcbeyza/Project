using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{

    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();//classın attributelarını oku
            var methodAttributes = type.GetMethod(method.Name)//metotun attributelarını oku
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }

    /*SelectInterceptors metodu, bir sınıf türü (type), bir metodun bilgisi (method) ve bir dizi IInterceptor (interceptors) alır. IInterceptor, bir metodun çağrıldığı zaman etkileşimler gerçekleştirebilen bir arabirimdir.

type üzerindeki GetCustomAttributes yöntemi kullanılarak sınıfa uygulanan öznitelikler alınır. Bu öznitelikler, MethodInterceptionBaseAttribute türündeki özniteliklerdir. İkinci parametre olan true, miras alınmış özniteliklerin de alınmasını sağlar. Sonuç bir liste olarak döner ve classAttributes değişkenine atanır.

method üzerindeki GetMethod yöntemi kullanılarak belirtilen metodun bilgisi alınır. Ardından, bu metot üzerinde uygulanan öznitelikler alınır. Yine, bu öznitelikler MethodInterceptionBaseAttribute türündedir. İkinci parametre olan true, miras alınmış özniteliklerin de alınmasını sağlar.

classAttributes listesi, methodAttributes listesi ile birleştirilir. Bu, sınıf üzerindeki özniteliklerin yanı sıra, belirli bir metoda özgü öznitelikleri de içermesini sağlar.

classAttributes listesi OrderBy yöntemi kullanılarak özniteliklerin Priority özelliğine göre sıralanır. Priority özelliği, özniteliklerin sıralama önceliğini belirlemek için kullanılan bir değerdir.

Son olarak, sıralanmış öznitelikler bir dizi olarak döndürülür. Bu dizideki öznitelikler, metodun çağrıldığı sırada ilgili etkileşimleri gerçekleştirmek üzere kullanılabilir.
     * 
     * 
     */
}
