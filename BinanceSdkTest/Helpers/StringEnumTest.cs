using BinanceSDK.Helpers;

namespace BinanceSdkTest.Helpers
{
  [TestClass]
  public class StringEnumTest
  {
    [TestMethod]
    public void ShouldBeEqualWhenClassIsTheSame()
    {
      Assert.AreNotEqual(MyEnum1.Value1, "v1");

      Assert.AreEqual(MyEnum1.Value1, MyEnum1.Value1);
      Assert.AreNotEqual(MyEnum2.Value1, MyEnum1.Value1);
		}


    [TestMethod]
    public void ShouldParseVeryWell()
    {
      Assert.AreEqual(MyEnum1.Value1, StringEnum.Parse<MyEnum1>("v1"));
      Assert.AreEqual(MyEnum2.Value2, StringEnum.Parse<MyEnum2>("v2"));
		}


    private sealed class MyEnum1 : StringEnum
    {
      private MyEnum1(string value) : base(value) { }


      public static readonly MyEnum1 Value1 = new MyEnum1("v1");
      public static readonly MyEnum1 Value2 = new MyEnum1("v2");
		}


		private sealed class MyEnum2 : StringEnum
		{
			private MyEnum2(string value) : base(value) { }


			public static readonly MyEnum2 Value1 = new MyEnum2("v1");
			public static readonly MyEnum2 Value2 = new MyEnum2("v2");
		}
	}
}
