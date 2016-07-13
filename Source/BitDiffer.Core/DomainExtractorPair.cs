using System;
using System.Collections.Generic;
using System.Text;
using BitDiffer.Extractor;

namespace BitDiffer.Core
{
    [Serializable]
	public class DomainExtractorPair
	{
		AppDomain _domain;
		AssemblyExtractor _extractor;

		public DomainExtractorPair(AppDomain domain, AssemblyExtractor extractor)
		{
			_extractor = extractor;
			_domain = domain;
            _domain.AssemblyResolve += Domain_AssemblyResolve;

        }

        private System.Reflection.Assembly Domain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            return null;
        }

        public AppDomain Domain
		{
			get { return _domain; }
		}

		public AssemblyExtractor Extractor
		{
			get { return _extractor; }
		}
	}
}
