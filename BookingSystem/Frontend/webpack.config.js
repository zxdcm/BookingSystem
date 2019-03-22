const webpack = require("webpack");

module.exports = {
  entry: "./src/index.js",
  module: {
    rules: [
      {
        test: /\.(js|jsx)$/,
        exclude: /node_modules/,
        use: ["babel-loader"]
      },
      {
        test: /\.css$/,
        loader: 'style-loader!css-loader'
    },
    {
        test: /\.s[a|c]ss$/,
        loader: 'sass-loader!style-loader!css-loader'
    },
    {
        test: /\.(jpg|png|gif|jpeg|woff|woff2|eot|ttf|svg)$/,
        loader: 'url-loader?limit=100000'
    }
    ]
  },
  resolve: {
    extensions: ["*", ".js", ".jsx"]
  },
  output: {
    path: __dirname + "/dist",
    publicPath: "/",
    filename: "bundle.js"
  },
  plugins: [new webpack.HotModuleReplacementPlugin()],
  devServer: {
    contentBase: "./dist",
    hot: true
  }
};
