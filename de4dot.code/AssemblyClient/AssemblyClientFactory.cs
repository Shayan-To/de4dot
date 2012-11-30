﻿/*
    Copyright (C) 2011-2012 de4dot@gmail.com

    This file is part of de4dot.

    de4dot is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    de4dot is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with de4dot.  If not, see <http://www.gnu.org/licenses/>.
*/

namespace de4dot.code.AssemblyClient {
	public interface IAssemblyClientFactory {
		IAssemblyClient create();
	}

	public class SameAppDomainAssemblyClientFactory : IAssemblyClientFactory {
		public IAssemblyClient create() {
			return new AssemblyClient(new SameAppDomainAssemblyServerLoader());
		}
	}

	public class NewAppDomainAssemblyClientFactory : IAssemblyClientFactory {
		public IAssemblyClient create() {
			return new AssemblyClient(new NewAppDomainAssemblyServerLoader());
		}
	}

	public class NewProcessAssemblyClientFactory : IAssemblyClientFactory {
		ServerClrVersion serverVersion;

		public NewProcessAssemblyClientFactory() {
			this.serverVersion = ServerClrVersion.CLR_ANY_ANYCPU;
		}

		internal NewProcessAssemblyClientFactory(ServerClrVersion serverVersion) {
			this.serverVersion = serverVersion;
		}

		public IAssemblyClient create() {
			return new AssemblyClient(new NewProcessAssemblyServerLoader(serverVersion));
		}
	}
}
