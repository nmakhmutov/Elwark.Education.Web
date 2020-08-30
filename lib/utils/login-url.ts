const createLoginUrl = (redirectTo?: string) => {
    if (redirectTo)
        return `/api/login?redirectTo=${encodeURIComponent(redirectTo)}`;

    return `/api/login`;
}

export default createLoginUrl;
