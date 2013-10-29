using System.IO;
using Toolbox.IO;

namespace SharedSafe.Encoding.Cryptography
{
	sealed class ReusableMemoryStream : Stream
	{
		readonly MemoryStream _stream;

		public ReusableMemoryStream()
		{
			_stream = new MemoryStream();
		}

		public override void Close()
		{
			_stream.SetLength(0);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
				_stream.Dispose();

			base.Dispose(disposing);
		}

		public BufferReference asBufferReference()
		{
			return _stream.asBufferReference();
		}

		#region Stream

		public override void Flush()
		{
			_stream.Flush();
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return _stream.Seek(offset, origin);
		}

		public override void SetLength(long value)
		{
			_stream.SetLength(value);
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return _stream.Read(buffer, offset, count);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			_stream.Write(buffer, offset, count);
		}

		public override bool CanRead
		{
			get { return _stream.CanRead; }
		}

		public override bool CanSeek
		{
			get { return _stream.CanSeek; }
		}

		public override bool CanWrite
		{
			get { return _stream.CanWrite; }
		}

		public override long Length
		{
			get { return _stream.Length; }
		}

		public override long Position
		{
			get { return _stream.Position; }
			set { _stream.Position = value; }
		}

		#endregion
	}
}
