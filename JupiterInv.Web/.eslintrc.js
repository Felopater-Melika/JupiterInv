module.exports = {
    parser: "@typescript-eslint/parser",
    plugins: [
        "@typescript-eslint",
        "prettier"
    ],
    extends: [
        "plugin:@typescript-eslint/recommended",
        "prettier/@typescript-eslint",
        "next/core-web-vitals",
        "plugin:prettier/recommended"
    ],
    rules: {
        "prettier/prettier": "error",
    }
};
