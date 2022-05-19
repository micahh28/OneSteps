module.exports = {
    title: 'OneSteps',
    description: '不积跬步无以至千里',
    head: [ // 注入到当前页面的 HTML <head> 中的标签
        ['link', {
            rel: 'icon',
            href: '/logo.png'
        }],
        ['link', {
            rel: 'manifest',
            href: '/logo.png'
        }],
        ['link', {
            rel: 'apple-touch-icon',
            href: '/logo.png'
        }],
        ['meta', {
            'http-quiv': 'pragma',
            cotent: 'no-cache'
        }],
        ['meta', {
            'http-quiv': 'pragma',
            cotent: 'no-cache,must-revalidate'
        }],
        ['meta', {
            'http-quiv': 'expires',
            cotent: '0'
        }]
    ],
    base: '/onesteps/', // 部署到github相关的配置
    markdown: {
        lineNumbers: true // 代码块是否显示行号
    },
    themeConfig: {
        nav: [ // 导航栏配置
            {
                text: '指北',
                link: '/guide/introduction'
            },
            {
                text: 'core',
                link: '/guide/configer'
            },
            {
                text: 'DatabaseAccessor',
                link: '/guide/cloudencrypt'
            },
            {
                text: 'Utils',
                link: '/guide/utility'
            },
        ],
        sidebar: 'auto', // 侧边栏配置
        sidebarDepth: 2
    }
};