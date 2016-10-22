const conf = require('./gulp.conf');
var proxyMiddleware = require('http-proxy-middleware');


module.exports = function () {
    var middleware = undefined;
    // uncomment this line to configure a proxy
    middleware = proxyMiddleware('/api', {target: 'http://localhost:50866', changeOrigin: 'localhost'});

  return {
    server: {
      baseDir: [
        conf.paths.tmp,
        conf.paths.src
      ],
      middleware: middleware
    },
    open: false
  };
};
