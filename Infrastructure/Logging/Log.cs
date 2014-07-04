﻿
namespace FC.Framework
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using FC.Framework.Utilities;

    public class Log
    {
        private static ILog InnerLogger
        {
            get
            {
                return IoC.Resolve<ILog>();
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Info(string message)
        {
            Check.Argument.IsNotEmpty(message, "message");
            if (InnerLogger != null)
                InnerLogger.Info(message);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Info(string format, params object[] args)
        {
            Check.Argument.IsNotEmpty(format, "format");

            if (args == null || args.Length == 0)
                InnerLogger.Info(format);
            else if (InnerLogger != null)
                InnerLogger.Info(Format(format,args));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Debug(string message)
        {
            Check.Argument.IsNotEmpty(message, "message");

            if (InnerLogger != null)
                InnerLogger.Debug(message);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Debug(string format, params object[] args)
        {
            Check.Argument.IsNotEmpty(format, "format");
             
            if (args == null || args.Length == 0)
                InnerLogger.Debug(format);
            else if (InnerLogger != null)
                InnerLogger.Debug(Format(format,args));
        }


        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Warn(string format, params object[] args)
        {
            Check.Argument.IsNotEmpty(format, "format"); 

            if (args == null || args.Length == 0)
                InnerLogger.Warn(format);
            else if (InnerLogger != null)
                InnerLogger.Warn(Format(format,args));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Warn(string message, Exception exception)
        {
            Check.Argument.IsNotEmpty(message, "message");
            Check.Argument.IsNotNull(exception, "exception");

            if (InnerLogger != null)
                InnerLogger.Warn(message, exception);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Error(string format, params object[] args)
        {
            Check.Argument.IsNotEmpty(format, "format"); 

            if (args == null || args.Length == 0)
                InnerLogger.Error(format);
            else if (InnerLogger != null)
                InnerLogger.Error(Format(format,args));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Error(string message, Exception exception)
        {
            Check.Argument.IsNotEmpty(message, "message");
            Check.Argument.IsNotNull(exception, "exception");

            if (InnerLogger != null)
                InnerLogger.Error(message, exception);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Fatal(string format, params object[] args)
        {
            Check.Argument.IsNotEmpty(format, "format");

            if (args == null || args.Length == 0)
                InnerLogger.Fatal(format);
            else if (InnerLogger != null)
                InnerLogger.Fatal(Format(format,args));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Fatal(string message, Exception exception)
        {
            Check.Argument.IsNotNull(exception, "exception");

            if (InnerLogger != null)
                InnerLogger.Fatal(message, exception);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static string Format(string format, params object[] args)
        {
            Check.Argument.IsNotEmpty(format, "format");

            return format.FormatWith(args);
        }
    }
}
