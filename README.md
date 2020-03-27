# csjvm
使用C#写的简单JVM

#### 介绍
项目中未使用到第三方库，.NET版本为：4.6.1

类解析参照java8：https://docs.oracle.com/javase/specs/jvms/se8/html/jvms-4.html


#### 使用说明

1.  克隆下来本项目`git clone https://github.com/ysdxz207/csjvm.git`
2.  使用Visual Studio 2019或Jetbrains Rider打开本项目运行

#### 实现目标

- - [x] 解析classpath

  - - [x] 解析boot classpath

  - - [x] 解析ext classpath

  - - [x] 解析user classpath

- - [x] 解析class

  - - [x] 魔数及校验
  - - [x] 次版本号，主版本号校验
  - - [x] 解析常量池
  - - [x] 解析类访问修饰符
  - - [x] 解析当前类
  - - [x] 解析父类
  - - [x] 解析包含的接口数组
  - - [x] 解析包含的字段数组
  - - [x] 解析包含的方法数组
  - - [x] 解析包含的属性数组
  








