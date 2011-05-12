﻿//-----------------------------------------------------------------------
// <copyright file="ICryptoKeyStore.cs" company="Andrew Arnott">
//     Copyright (c) Andrew Arnott. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace DotNetOpenAuth {
	using System;
	using System.Collections.Generic;
	using System.Diagnostics.Contracts;
	using System.Linq;
	using System.Text;
	using DotNetOpenAuth.Messaging;

	/// <summary>
	/// A persistent store for rotating symmetric cryptographic keys.
	/// </summary>
	/// <remarks>
	/// Implementations should persist it in such a way that the keys are shared across all servers
	/// on a web farm, where applicable.  
	/// The store should consider protecting the persistent store against theft resulting in the loss
	/// of the confidentiality of the keys.  One possible mitigation is to asymmetrically encrypt
	/// each key using a certificate installed in the server's certificate store.
	/// </remarks>
	[ContractClass(typeof(ICryptoKeyStoreContract))]
	public interface ICryptoKeyStore {
		/// <summary>
		/// Gets the key in a given bucket and handle.
		/// </summary>
		/// <param name="bucket">The bucket name.  Case sensitive.</param>
		/// <param name="handle">The key handle.  Case sensitive.</param>
		/// <returns>The cryptographic key, or <c>null</c> if no matching key was found.</returns>
		CryptoKey GetKey(string bucket, string handle);

		/// <summary>
		/// Gets a sequence of existing keys within a given bucket.
		/// </summary>
		/// <param name="bucket">The bucket name.  Case sensitive.</param>
		/// <returns>A sequence of handles and keys, ordered by descending <see cref="CryptoKey.ExpiresUtc"/>.</returns>
		IEnumerable<KeyValuePair<string, CryptoKey>> GetKeys(string bucket);

		/// <summary>
		/// Stores a cryptographic key.
		/// </summary>
		/// <param name="bucket">The name of the bucket to store the key in.  Case sensitive.</param>
		/// <param name="handle">The handle to the key, unique within the bucket.  Case sensitive.</param>
		/// <param name="key">The key to store.</param>
		void StoreKey(string bucket, string handle, CryptoKey key);

		/// <summary>
		/// Removes the key.
		/// </summary>
		/// <param name="bucket">The bucket name.  Case sensitive.</param>
		/// <param name="handle">The key handle.  Case sensitive.</param>
		void RemoveKey(string bucket, string handle);
	}

	/// <summary>
	/// Code contract for the <see cref="ICryptoKeyStore"/> interface.
	/// </summary>
	[ContractClassFor(typeof(ICryptoKeyStore))]
	internal abstract class ICryptoKeyStoreContract : ICryptoKeyStore {
		/// <summary>
		/// See the <see cref="ICryptoKeyStore"/> interface.
		/// </summary>
		CryptoKey ICryptoKeyStore.GetKey(string bucket, string handle) {
			Contract.Requires<ArgumentException>(!String.IsNullOrEmpty(bucket));
			Contract.Requires<ArgumentException>(!String.IsNullOrEmpty(handle));
			throw new NotImplementedException();
		}

		/// <summary>
		/// See the <see cref="ICryptoKeyStore"/> interface.
		/// </summary>
		IEnumerable<KeyValuePair<string, CryptoKey>> ICryptoKeyStore.GetKeys(string bucket) {
			Contract.Requires<ArgumentException>(!String.IsNullOrEmpty(bucket));
			Contract.Ensures(Contract.Result<IEnumerable<KeyValuePair<string, CryptoKey>>>() != null);
			throw new NotImplementedException();
		}

		/// <summary>
		/// See the <see cref="ICryptoKeyStore"/> interface.
		/// </summary>
		void ICryptoKeyStore.StoreKey(string bucket, string handle, CryptoKey key) {
			Contract.Requires<ArgumentException>(!String.IsNullOrEmpty(bucket));
			Contract.Requires<ArgumentException>(!String.IsNullOrEmpty(handle));
			Contract.Requires<ArgumentNullException>(key != null, "key");
			throw new NotImplementedException();
		}

		/// <summary>
		/// See the <see cref="ICryptoKeyStore"/> interface.
		/// </summary>
		void ICryptoKeyStore.RemoveKey(string bucket, string handle) {
			Contract.Requires<ArgumentException>(!String.IsNullOrEmpty(bucket));
			Contract.Requires<ArgumentException>(!String.IsNullOrEmpty(handle));
			throw new NotImplementedException();
		}
	}
}
