const path = require("path")
module.exports = {
  mode: 'production',
  entry: ['./src/index.js', './src/style.css'],
  module: {
    rules: [
      { test: /\.css$/, use: ['style-loader', 'css-loader'] },
      { test: /\.(jpe?g|png|gif|svg)$/i, use: 'file-loader' }
    ]
  },
  output: {
    path: path.resolve(__dirname, 'dist'),
    filename: 'index.bundle.js',
    publicPath: '_content/MyRazorClassLibrary/dist/' // << See note
  }
};
