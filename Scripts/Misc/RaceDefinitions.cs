using System;
using Server;

namespace Server.Misc
{
	public class RaceDefinitions
	{
		public static void Configure()
		{
			/* Here we configure all races. Some notes:
			 * 
			 * 1) The first 32 races are reserved for core use.
			 * 2) Race 0x7F is reserved for core use.
			 * 3) Race 0xFF is reserved for core use.
			 * 4) Changing or removing any predefined races may cause server instability.
			 */

			RegisterRace( new Human	( 0, 0 ) );
			RegisterRace( new Human	( 1, 1 ) ); // no elf
		}

		public static void RegisterRace( Race race )
		{
			Race.Races[race.RaceIndex] = race;
			Race.AllRaces.Add( race );
		}

		private class Human : Race
		{
			public Human( int raceID, int raceIndex )
				: base( raceID, raceIndex, "Human", "Humans", 400, 401, 402, 403, Expansion.None )
			{
			}

			public override bool ValidateHair( bool female, int itemID )
			{
				if( itemID == 0 )
					return true;

				if( (female && itemID == 0x2048) || (!female && itemID == 0x2046 ) )
					return false;	//Buns & Receeding Hair

				if( itemID >= 0x203B && itemID <= 0x203D )
					return true;

				if( itemID >= 0x2044 && itemID <= 0x204A )
					return true;

				return false;
			}

			public override int RandomHair( bool female )	//Random hair doesn't include baldness
			{
				switch( Utility.Random( 9 ) )
				{
					case 0: return 0x203B;	//Short
					case 1: return 0x203C;	//Long
					case 2: return 0x203D;	//Pony Tail
					case 3: return 0x2044;	//Mohawk
					case 4: return 0x2045;	//Pageboy
					case 5: return 0x2047;	//Afro
					case 6: return 0x2049;	//Pig tails
					case 7: return 0x204A;	//Krisna
					default: return (female ? 0x2046 : 0x2048);	//Buns or Receeding Hair
				}
			}

			public override bool ValidateFacialHair( bool female, int itemID )
			{
				if( itemID == 0 )
					return true;

				if( female )
					return false;

				if( itemID >= 0x203E && itemID <= 0x2041 )
					return true;

				if( itemID >= 0x204B && itemID <= 0x204D )
					return true;

				return false;
			}

			public override int RandomFacialHair( bool female )
			{
				if( female )
					return 0;

				int rand = Utility.Random( 7 );

				return ((rand < 4) ? 0x203E : 0x2047) + rand;
			}

			public override int ClipSkinHue( int hue )
			{
				if( hue < 1002 )
					return 1002;
				else if( hue > 1058 )
					return 1058;
				else
					return hue;
			}

			public override int RandomSkinHue()
			{
				return Utility.Random( 1002, 57 ) | 0x8000;
			}

			public override int ClipHairHue( int hue )
			{
				if( hue < 1102 )
					return 1102;
				else if( hue > 1149 )
					return 1149;
				else
					return hue;
			}

			public override int RandomHairHue()
			{
				return Utility.Random( 1102, 48 );
			}
		}

		private class Elf : Race
		{
			private static int[] m_SkinHues = new int[]
				{
					0x0BF, 0x24D, 0x24E, 0x24F, 0x353, 0x361, 0x367, 0x374,
					0x375, 0x376, 0x381, 0x382, 0x383, 0x384, 0x385, 0x389,
					0x3DE, 0x3E5, 0x3E6, 0x3E8, 0x3E9, 0x430, 0x4A7, 0x4DE,
					0x51D, 0x53F, 0x579, 0x76B, 0x76C, 0x76D, 0x835, 0x903
				};

			private static int[] m_HairHues = new int[]
				{
					0x034, 0x035, 0x036, 0x037, 0x038, 0x039, 0x058, 0x08E,
					0x08F, 0x090, 0x091, 0x092, 0x101, 0x159, 0x15A, 0x15B,
					0x15C, 0x15D, 0x15E, 0x128, 0x12F, 0x1BD, 0x1E4, 0x1F3,
					0x207, 0x211, 0x239, 0x251, 0x26C, 0x2C3, 0x2C9, 0x31D,
					0x31E, 0x31F, 0x320, 0x321, 0x322, 0x323, 0x324, 0x325,
					0x326, 0x369, 0x386, 0x387, 0x388, 0x389, 0x38A, 0x59D,
					0x6B8, 0x725, 0x853
				};

			public Elf( int raceID, int raceIndex )
				: base( raceID, raceIndex, "Elf", "Elves", 605, 606, 607, 608, Expansion.ML )
			{
			}

			public override bool ValidateHair( bool female, int itemID )
			{
				if( itemID == 0 )
					return true;

				if( (female && (itemID == 0x2FCD || itemID == 0x2FBF)) || (!female && (itemID == 0x2FCC || itemID == 0x2FD0)) )
					return false;

				if( itemID >= 0x2FBF && itemID <= 0x2FC2 )
					return true;

				if( itemID >= 0x2FCC && itemID <= 0x2FD1 )
					return true;

				return false;
			}

			public override int RandomHair( bool female )	//Random hair doesn't include baldness
			{
				switch( Utility.Random( 8 ) )
				{
					case 0: return 0x2FC0;	//Long Feather
					case 1: return 0x2FC1;	//Short
					case 2: return 0x2FC2;	//Mullet
					case 3: return 0x2FCE;	//Knob
					case 4: return 0x2FCF;	//Braided
					case 5: return 0x2FD1;	//Spiked
					case 6: return (female ? 0x2FCC : 0x2FBF);	//Flower or Mid-long
					default: return (female ? 0x2FD0 : 0x2FCD);	//Bun or Long
				}
			}

			public override bool ValidateFacialHair( bool female, int itemID )
			{
				return (itemID == 0);
			}

			public override int RandomFacialHair( bool female )
			{
				return 0;
			}

			public override int ClipSkinHue( int hue )
			{
				for( int i = 0; i < m_SkinHues.Length; i++ )
					if( m_SkinHues[i] == hue )
						return hue;

				return m_SkinHues[0];
			}

			public override int RandomSkinHue()
			{
				return m_SkinHues[Utility.Random( m_SkinHues.Length )] | 0x8000;
			}

			public override int ClipHairHue( int hue )
			{
				for( int i = 0; i < m_HairHues.Length; i++ )
					if( m_HairHues[i] == hue )
						return hue;

				return m_HairHues[0];
			}

			public override int RandomHairHue()
			{
				return m_HairHues[Utility.Random( m_HairHues.Length )];
			}
		}
	}
}