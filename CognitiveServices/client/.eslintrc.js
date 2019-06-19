module.exports = {
  root: true,
  env: {
    node: true,
  },
  extends: [
    'plugin:vue/essential',
    '@vue/airbnb',
  ],
  rules: {
    'no-console': process.env.NODE_ENV === 'production' ? 'error' : 'off',
    'no-debugger': process.env.NODE_ENV === 'production' ? 'error' : 'off',
    'linebreak-style': ["error", "windows"],
    'no-param-reassign': 'off',
    'import/prefer-default-export': 'off',
    'guard-for-in': 'off',
    'no-nested-ternary': 'off'
  },
  parserOptions: {
    parser: 'babel-eslint',
  },
};
