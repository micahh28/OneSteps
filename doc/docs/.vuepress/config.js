module.exports = {
    title: 'YGXJ-Core',
    description: '核心库文档',
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
    base: '/', // 部署到github相关的配置
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
                text: '可视化配置',
                link: '/guide/configer'
            },
            {
                text: '云加密',
                link: '/guide/cloudencrypt'
            },
            {
                text: 'C#工具',
                link: '/guide/utility'
            },
        ],
        sidebar: 'auto', // 侧边栏配置
        sidebarDepth: 2
    }
};