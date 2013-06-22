/* DO NOT EDIT *** This file was generated automatically *** DO NOT EDIT */

//
// Authors:
//	Sebastien Pouliot  <sebastien@ximian.com>
//
// Copyright (C) 2006 Novell, Inc (http://www.novell.com)
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// 'Software'), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED 'AS IS', WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using System.Security.Cryptography;

using Crimson.MHash;

namespace Crimson.Security.Cryptography {

	public class GOSTNative : GOST {

		private MHashId Id = MHashId.Gost;
		private MHashHelper hash;

		public GOSTNative ()
		{
			hash = new MHashHelper (Id);
		}

		~GOSTNative ()
		{
			Dispose ();
		}

		public void Dispose () 
		{
			if (hash.Handle != IntPtr.Zero) {
				hash.Dispose ();
				GC.SuppressFinalize (this);
			}
		}

		public override void Initialize ()
		{
			if (hash.Handle == IntPtr.Zero) {
				GC.ReRegisterForFinalize (this);
				hash.Initialize ();
			}
		}

		protected override void HashCore (byte[] data, int start, int length) 
		{
			if (hash.Handle == IntPtr.Zero)
				Initialize ();

			hash.HashCore (data, start, length);
		}

		protected override byte[] HashFinal () 
		{
			if (hash.Handle == IntPtr.Zero)
				Initialize ();

			return hash.HashFinal ();
		}
	}
}
/* DO NOT EDIT *** This file was generated automatically *** DO NOT EDIT */
