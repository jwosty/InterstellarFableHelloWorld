var path = require("path");
var webpack = require("webpack");

function resolve(filePath) {
    return path.join(__dirname, filePath)
}

var isProduction = process.argv.indexOf("-p") >= 0;
console.log("Bundling for " + (isProduction ? "production" : "development") + "...");
// configures whether or not to run webpack in watch mod
var enableWatch = process.argv.indexOf("-w") >= 0;

module.exports = {
    mode: "development",
    devtool: "source-map", // Generates source maps
    entry: resolve('./HelloWorld.FableUI.fsproj'),
    output: { // The file to output and the directory to place it in
        filename: 'bundle.js',
        path: resolve('../Resources/wwwroot/scripts'),
    },
    watch: enableWatch,
    optimization: {
        // Split the code coming from npm packages into a different file.
        // 3rd party dependencies change less often, let the browser cache them.
        splitChunks: {
            cacheGroups: {
                commons: {
                    test: /node_modules/,
                    name: "vendors",
                    chunks: "all"
                }
            }
        },
    },
    //plugins: [
    //    new webpack.HotModuleReplacementPlugin()
    //],
    resolve: {
        modules: [
            "node_modules", resolve("./node_modules/")
        ]
    },
    module: {
        rules: [
            {
                test: /\.fs(x|proj)?$/, // regex test for which files will be processed by fable-loader
                use: {
                    loader: "fable-loader",
                    options: {
                        define: isProduction ? [] : ["DEBUG"]
                    }
                }
            }
        ]
    }
};
