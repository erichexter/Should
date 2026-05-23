## Should Assertion Library

The **Should Assertion Library** provides extension methods for test assertions in AAA and BDD style tests. It is test-runner agnostic — use it with xUnit, NUnit, MSTest, or anything else. The assertions are based on a fork of the xUnit assertion library.

**Should** comes in two packages:

| Package | Description |
|---------|-------------|
| `Should` | Extension-method style assertions |
| `Should.Fluent` | Fluent chain style assertions |

Both target **netstandard2.0** (compatible with .NET Framework 4.6.1+, .NET Core 2.0+, .NET 5–9+) and **net9.0** (native for .NET 9 apps). NuGet picks the right build automatically.

---

### Installation

```
dotnet add package Should
dotnet add package ShouldFluent
```

---

### Standard API

```csharp
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
```

---

### Fluent API

```csharp
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
```

Additional fluent examples:

```csharp
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
date.Should().Be.Today();

var str = "";
str.Should().Be.NullOrEmpty();

var one = "1";
one.Should().Be.ConvertableTo<int>();

var idString = Guid.NewGuid().ToString();
idString.Should().Be.ConvertableTo<Guid>();
```

---

### Dependencies

The shipped packages have **no runtime dependencies**. `Should.Fluent` depends only on `Should.Core` (also part of this repo).

---

### Building and releasing

```
dotnet build src/Should.sln
dotnet test src/Should.sln
```

CI runs on every push. A NuGet release is published automatically when a `v*` tag is pushed:

```
git tag v2.0.1
git push origin v2.0.1
```

This requires a `NUGET_API_KEY` secret in the GitHub repo settings (Settings → Secrets → Actions).
