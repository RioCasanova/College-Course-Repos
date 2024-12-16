/** @type {import('next').NextConfig} */
const nextConfig = {
  reactStrictMode: false,
  env: {
    BASE_QUOTES_URL: process.env.BASE_QUOTES_URL,
    SUPER_PRIVATE_KEY: process.env.SUPER_PRIVATE_KEY,
  },
};

module.exports = nextConfig;
