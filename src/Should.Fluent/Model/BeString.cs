using System;
using System.ComponentModel;

namespace Should.Fluent.Model
{
    public class BeString
    {
        private readonly ShouldString should;
        private readonly IAssertProvider assertProvider;

        public BeString(ShouldString should, IAssertProvider assertProvider)
        {
            this.should = should;
            this.assertProvider = assertProvider;
        }

        public string Null()
        {
            return Check.IsNull(should, assertProvider);
        }

        public string Empty()
        {
            if (should.Negate)
            {
                assertProvider.AreNotEqual(string.Empty, should.Target);
            }
            else
            {
                assertProvider.AreEqual(string.Empty, should.Target);
            }
            return should.Target;
        }

        public string NullOrEmpty()
        {
            var targetNullOrEmpty = string.IsNullOrEmpty(should.Target);
            if (should.Negate)
            {
                assertProvider.IsFalse(targetNullOrEmpty);
            }
            else
            {
                assertProvider.IsTrue(targetNullOrEmpty);
            }
            return should.Target;
        }

        public T ConvertableTo<T>()
        {
            if (should.Negate)
            {
                try
                {
                    TypeDescriptor.GetConverter(typeof(T));
                    assertProvider.Fail("Could convert '{0}' to {1}.  Expected not covertable.", should.Target, typeof(T));
                }
                catch { }
            }
            else
            {
                try
                {
                    var converter = TypeDescriptor.GetConverter(typeof(T));
                    return (T)converter.ConvertFrom(should.Target);
                }
                catch (Exception ex)
                {
                    assertProvider.Fail("Could not convert '{0}' to {1}.  {3}", should.Target, typeof(T), ex.ToString());
                }
            }
            return default(T);
        }
    }
}