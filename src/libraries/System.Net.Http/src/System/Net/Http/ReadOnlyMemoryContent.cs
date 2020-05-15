// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http
{
    public sealed class ReadOnlyMemoryContent : HttpContent
    {
        private readonly ReadOnlyMemory<byte> _content;

        public ReadOnlyMemoryContent(ReadOnlyMemory<byte> content) =>
            _content = content;

        protected override Task SerializeToStreamAsync(Stream stream, TransportContext? context) =>
            stream.WriteAsync(_content).AsTask();

        protected override Task SerializeToStreamAsync(Stream stream, TransportContext? context, CancellationToken cancellationToken) =>
            stream.WriteAsync(_content, cancellationToken).AsTask();

        protected internal override bool TryComputeLength(out long length)
        {
            length = _content.Length;
            return true;
        }

        protected override Task<Stream> CreateContentReadStreamAsync() =>
            Task.FromResult<Stream>(new ReadOnlyMemoryStream(_content));

        internal override Stream TryCreateContentReadStream() =>
            new ReadOnlyMemoryStream(_content);

        internal override bool AllowDuplex => false;
    }
}
