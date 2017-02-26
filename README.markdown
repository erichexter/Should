This fork [![shoulduwp MyGet Build Status](https://www.myget.org/BuildSource/Badge/shoulduwp?identifier=b8cd0611-0efd-4271-b774-496f62f2c644)](https://www.myget.org/)

## Project Description

The **Should Assertion Library** provides a set of extension methods for test assertions for AAA and BDD style tests.  It provides assertions only, and as a result it is Test runner agnostic.  The assertions are a direct fork of the [xUnit](http://xunit.codeplex.com) test assertions.  This project was born because test runners *Should* be independent of the the assertions!

**Should Assertion Library** comes in two flavors, each with its own binary.

 * Standard (Should.dll)
 * Fluent (Should.Fluent.dll)

  Use our prerelease nuget feed: http://www.myget.org/F/should/

###Standard

Install from nuget.

    PM> install-package should

The following example shows some of the assertions that are available for objects, booleans, string, and collections.

    public void Should_assertions()
    {
       object obj = null;
       obj.ShouldBeNull();

        obj = new object();
        obj.ShouldBeType(typeof(object));
        obj.ShouldEqual(obj);
        obj.ShouldNotBeNull();
        obj.ShouldNotBeSameAs(new object());
        obj.ShouldNotBeType(typeof(string));
        obj.ShouldNotEqual("foo");

        obj = "x";
        obj.ShouldNotBeInRange("y", "z");
        obj.ShouldBeInRange("a", "z");
        obj.ShouldBeSameAs("x");

        "This String".ShouldContain("This");
        "This String".ShouldNotBeEmpty();
        "This String".ShouldNotContain("foobar");

        false.ShouldBeFalse();
        true.ShouldBeTrue();

        var list = new List<object>();
        list.ShouldBeEmpty();
        list.ShouldNotContain(new object());

        var item = new object();
        list.Add(item);
        list.ShouldNotBeEmpty();
        list.ShouldContain(item);
    }

###Fluent

Should.Fluent is a direct port of [ShouldIt](http://code.google.com/p/shouldit).  Install from nuget.

    PM> install-package ShouldFluent

The following shows the same assertions as above but in the fluent style.

    public void Should_fluent_assertions()
    {
        object obj = null;
        obj.Should().Be.Null();

        obj = new object();
  	 	obj.Should().Be.OfType(typeof(object));
    	obj.Should().Equal(obj);
	    obj.Should().Not.Be.Null();
	    obj.Should().Not.Be.SameAs(new object());
	    obj.Should().Not.Be.OfType<string>();
	    obj.Should().Not.Equal("foo");
	
	    obj = "x";
	    obj.Should().Not.Be.InRange("y", "z");
	    obj.Should().Be.InRange("a", "z");
	    obj.Should().Be.SameAs("x");
	
	    "This String".Should().Contain("This");
	    "This String".Should().Not.Be.Empty();
	    "This String".Should().Not.Contain("foobar");
	
	    false.Should().Be.False();
	    true.Should().Be.True();
	
	    var list = new List<object>();
	    list.Should().Count.Zero();
	    list.Should().Not.Contain.Item(new object());
	
	    var item = new object();
	    list.Add(item);
	    list.Should().Not.Be.Empty();
	    list.Should().Contain.Item(item);
	};

Here are some additional examples of assertions using the fluent API:

	public void Should_fluent_assertions()
	{
	    var numbers = new List<int> { 1, 1, 2, 3 };
	    numbers.Should().Contain.Any(x => x == 1);
	    numbers
	        .Should().Count.AtLeast(1)
	        .Should().Count.NoMoreThan(5)
	        .Should().Count.Exactly(4)
	        .Should().Contain.One(x => x > 2);
	
	    var id = new Guid();
	    id.Should().Be.Empty();
	
	    id = Guid.NewGuid();
	    id.Should().Not.Be.Empty();
	
	    var date = DateTime.Now;
	    date1.Should().Be.Today();
	
	    var str = "";
	    str.Should().Be.NullOrEmpty();                
	
	    var one = "1";
	    one.Should().Be.ConvertableTo<int>();
	
	    var idString = Guid.NewGuid().ToString();
	    idString.Should().Be.ConvertableTo<Guid>();
	}
