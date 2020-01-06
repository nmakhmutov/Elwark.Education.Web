module.exports = {
    devIndicators: {
        autoPrerender: true,
    },
    webpack(config) {
        config.resolve.modules.push(__dirname)
        return config;
    },
}
