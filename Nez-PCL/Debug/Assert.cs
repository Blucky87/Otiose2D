﻿using System;
using System.Diagnostics;


namespace Nez
{
	public static class Assert
	{
		[Conditional( "DEBUG" )]
		[DebuggerHidden]
		public static void isTrue( bool condition )
		{
			if( !condition )
			{
				System.Diagnostics.Debug.Assert( false );
				Debugger.Break();
			}
		}


		[Conditional( "DEBUG" )]
		[DebuggerHidden]
		public static void isTrue( bool condition, string message, params object[] args )
		{
			if( !condition )
			{
				System.Diagnostics.Debug.Assert( false, string.Format( message, args ) );
				Debugger.Break();
			}
		}


		[Conditional( "DEBUG" )]
		[DebuggerHidden]
		public static void isFalse( bool condition )
		{
			isTrue( !condition );
		}


		[Conditional( "DEBUG" )]
		[DebuggerHidden]
		public static void isFalse( bool condition, string message, params object[] args )
		{
			isTrue( !condition, message, args );
		}


		[Conditional( "DEBUG" )]
		[DebuggerHidden]
		public static void isNull( object obj, string message, params object[] args )
		{
			isTrue( obj == null, message, args );
		}


		[Conditional( "DEBUG" )]
		[DebuggerHidden]
		public static void isNotNull( object obj, string message, params object[] args )
		{
			isTrue( obj != null, message, args );
		}


		[Conditional( "DEBUG" )]
		[DebuggerHidden]
		public static void areEqual( object first, object second, string message, params object[] args )
		{
			if( first != second )
				System.Diagnostics.Debug.Assert( false, string.Format( message, args ) );
		}


		[Conditional( "DEBUG" )]
		[DebuggerHidden]
		public static void areNotEqual( object first, object second, string message, params object[] args )
		{
			if( first == second )
			{
				System.Diagnostics.Debug.Assert( false, string.Format( message, args ) );
				Debugger.Break();
			}
		}

	}
}

