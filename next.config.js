module.exports = {
    devIndicators: {
        autoPrerender: true,
    },
    webpack(config, {isServer}) {
        if (!isServer) {
            config.node = {
                fs: 'empty',
                net: 'empty',
                tls: 'empty'
            };
        }
        config.resolve.modules.push(__dirname)
        return config;
    },
}
