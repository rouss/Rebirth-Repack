using System; 
using System.Collections; using System.Collections.Generic; 
using Server.Items; 

namespace Server.Mobiles 
{ 
	public class SBFurtrader : SBInfo 
	{ 
		private ArrayList m_BuyInfo = new InternalBuyInfo(); 
		private IShopSellInfo m_SellInfo = new InternalSellInfo(); 

		public SBFurtrader() 
		{ 
		} 

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } } 
		public override ArrayList BuyInfo { get { return m_BuyInfo; } } 

		public class InternalBuyInfo : ArrayList 
		{ 
			public InternalBuyInfo() 
			{ 
				Add( new GenericBuyInfo( typeof( Hides ), 7, 40, 0x1079, 0 ) ); 
				Add( new GenericBuyInfo( typeof( DarkFur ), 8, 999, 0x11F4, 0 ) ); 
				Add( new GenericBuyInfo( typeof( LightFur ), 8, 999, 0x11F6, 0 ) ); 
			} 
		} 

		public class InternalSellInfo : GenericSellInfo 
		{ 
			public InternalSellInfo() 
			{ 
				Add( typeof( Hides ), 3 ); 
				Add( typeof( DarkFur ), 4 ); 
				Add( typeof( LightFur ), 4 ); 
			} 
		} 
	} 
} 
