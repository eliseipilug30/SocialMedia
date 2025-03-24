const { defineConfig } = require('@vue/cli-service');
module.exports = defineConfig({
  transpileDependencies: true,
  devServer: {
    proxy: {
      '/api': {
        target: 'http://localhost:8080', // Corect: backend-ul rulează pe 8080
        changeOrigin: true,
        pathRewrite: { '^/api': '' },
      },
    },
  },
});
