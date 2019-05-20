export interface ServerError extends Error {
    result: {
        ClassName: string;
        Message: string;
        Data: null;
        InnerException: {
            ClassName: string;
            Message: string;
            Data: {};
            InnerException: null;
            HelpURL: null;
            StackTraceString: string;
            RemoteStackTraceString: null;
            RemoteStackIndex: number;
            ExceptionMethod: null;
            HResult: number;
            Source: string;
            WatsonBuckets: null;
        };
        HelpURL: null;
        StackTraceString: null;
        RemoteStackTraceString: null;
        RemoteStackIndex: 0;
        ExceptionMethod: null;
        HResult: number;
        Source: null;
        WatsonBuckets: null;
    }[];
    name: string;
    response: object;
    statusCode: number;
}
