export default class AccessTokenError extends Error {
    public code: string;

    constructor(code: string, message: string) {
        super(message);

        this.name = this.constructor.name;

        Error.captureStackTrace(this, this.constructor);

        this.code = code;
    }
}
